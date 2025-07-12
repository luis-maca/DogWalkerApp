using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalkerApp.Infrastructure.Services
{
    public class DogWalkService : IDogWalkService
    {
        private readonly DogWalkerDbContext _context;

        public DogWalkService(DogWalkerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DogWalkDto> GetAll()
        {
            var walks = _context.DogWalks
                .Include(w => w.Walker)
                .Include(w => w.Dogs).ThenInclude(dw => dw.Dog).ThenInclude(d => d.Client)
                .ToList();

            return walks.Select(w => new DogWalkDto
            {
                Id = w.Id,
                WalkerId = w.WalkerId,
                WalkerName = w.Walker.FullName,
                WalkDate = w.WalkDate,
                DurationMinutes = w.DurationMinutes,
                DogIds = w.Dogs.Select(d => d.DogId).ToList(),
                DogNames = w.Dogs.Select(d => d.Dog.Name).ToList(),
                ClientNames = w.Dogs.Select(d => d.Dog.Client.Name).Distinct().ToList()
            });
        }

        public DogWalkDto? GetById(int id) => GetAll().FirstOrDefault(w => w.Id == id);

        public IEnumerable<DogWalkDto> GetByDateRange(DateTime start, DateTime end) =>
            GetAll().Where(w => w.WalkDate.Date >= start.Date && w.WalkDate.Date <= end.Date).ToList();

        public IEnumerable<DogWalkDto> Search(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return GetAll();

            term = term.ToLower();

            return GetAll()
                .Where(w => w.ClientNames.Any(c => c.ToLower().Contains(term)) ||
                            w.DogNames.Any(d => d.ToLower().Contains(term)))
                .ToList();
        }

        public void Create(DogWalkDto dto)
        {
            if (dto.DogIds == null || !dto.DogIds.Any())
                throw new Exception("At least one dog must be selected for the walk.");

            var walkStart = dto.WalkDate;
            var duration = GetDefaultWalkTimeInMinutes();
            var walkEnd = walkStart.AddMinutes(duration);

            var walker = _context.Walkers.FirstOrDefault(w => w.Id == dto.WalkerId);
            if (walker == null || !walker.IsAvailable)
                throw new Exception("Walker is not available.");

            // Check for overlapping walks for the same walker
            var overlappingWalks = _context.DogWalks
                .Where(w => w.WalkerId == dto.WalkerId && w.WalkDate.Date == dto.WalkDate.Date)
                .ToList();

            foreach (var walk in overlappingWalks)
            {
                var start = walk.WalkDate;
                var end = start.AddMinutes(walk.DurationMinutes);

                if (walkStart < end.AddMinutes(30) && walkEnd > start.AddMinutes(-30))
                    throw new Exception("Walker must have at least 30 minutes between walks.");
            }

            // Check max dogs per walk
            var maxDogsPerWalk = int.Parse(_context.AppConfigurations.FirstOrDefault(c => c.Key == "MaxDogsPerWalk")?.Value ?? "3");
            var countAtSameTime = _context.DogWalkDogs
                .Include(x => x.DogWalk)
                .Count(x => x.DogWalk.WalkDate == dto.WalkDate && x.DogWalk.WalkerId == dto.WalkerId);

            if ((countAtSameTime + dto.DogIds.Count) > maxDogsPerWalk)
                throw new Exception($"Cannot assign more than {maxDogsPerWalk} dogs for the same walk.");

            foreach (var dogId in dto.DogIds)
            {
                var dog = _context.Dogs.Include(d => d.Client).FirstOrDefault(d => d.Id == dogId)
                          ?? throw new Exception("Dog not found.");

                var sub = _context.Subscriptions.FirstOrDefault(s => s.ClientId == dog.ClientId);
                if (sub == null || !sub.IsActive)
                    throw new Exception($"Client '{dog.Client.Name}' must have an active subscription.");

                var walksToday = _context.DogWalkDogs
                    .Include(wd => wd.DogWalk)
                    .Count(wd => wd.Dog.ClientId == dog.ClientId && wd.DogWalk.WalkDate.Date == dto.WalkDate.Date);

                if (walksToday >= sub.MaxDogsAllowed)
                    throw new Exception($"Client '{dog.Client.Name}' cannot schedule more than {sub.MaxDogsAllowed} dogs per day.");

                var existingWalks = _context.DogWalkDogs
                    .Include(x => x.DogWalk)
                    .Where(x => x.DogId == dogId && x.DogWalk.WalkDate.Date == dto.WalkDate.Date)
                    .Select(x => x.DogWalk)
                    .ToList();

                foreach (var existing in existingWalks)
                {
                    var start = existing.WalkDate;
                    var end = start.AddMinutes(existing.DurationMinutes);

                    if (walkStart < end && walkEnd > start)
                        throw new Exception($"Dog '{dog.Name}' already has a conflicting walk.");
                }
            }

            var walkEntity = new DogWalk
            {
                WalkerId = dto.WalkerId,
                WalkDate = dto.WalkDate,
                DurationMinutes = duration
            };

            _context.DogWalks.Add(walkEntity);
            _context.SaveChanges();

            foreach (var dogId in dto.DogIds)
            {
                _context.DogWalkDogs.Add(new DogWalkDog
                {
                    DogId = dogId,
                    DogWalkId = walkEntity.Id
                });
            }

            _context.SaveChanges();
        }

        public void Update(DogWalkDto dto)
        {
            var walk = _context.DogWalks.Include(w => w.Dogs).FirstOrDefault(w => w.Id == dto.Id);
            if (walk == null) return;

            // Clear old relations
            _context.DogWalkDogs.RemoveRange(walk.Dogs);
            _context.SaveChanges();

            // Reuse Create logic after resetting
            var tempDto = new DogWalkDto
            {
                WalkerId = dto.WalkerId,
                WalkDate = dto.WalkDate,
                DogIds = dto.DogIds
            };

            Delete(dto.Id);
            Create(tempDto);
        }

        public void Delete(int id)
        {
            var walk = _context.DogWalks.Include(w => w.Dogs).FirstOrDefault(w => w.Id == id);
            if (walk == null) return;

            _context.DogWalkDogs.RemoveRange(walk.Dogs);
            _context.DogWalks.Remove(walk);
            _context.SaveChanges();
        }

        private int GetDefaultWalkTimeInMinutes()
        {
            var value = _context.AppConfigurations.FirstOrDefault(c => c.Key == "DefaultWalkTime")?.Value ?? "30";
            return int.TryParse(value, out var minutes) ? minutes : 30;
        }
    }
}
