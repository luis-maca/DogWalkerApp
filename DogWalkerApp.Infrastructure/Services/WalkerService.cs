using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Infrastructure.Data;

namespace DogWalkerApp.Infrastructure.Services;

public class WalkerService : IWalkerService
{
    private readonly DogWalkerDbContext _context;

    public WalkerService(DogWalkerDbContext context)
    {
        _context = context;
    }

    public List<WalkerDto> GetAll()
    {
        return _context.Walkers
            .Where(w => !w.IsDeleted)
            .Select(w => new WalkerDto
            {
                Id = w.Id,
                FullName = w.FullName,
                PhoneNumber = w.PhoneNumber,
                IsAvailable = w.IsAvailable
            }).ToList();
    }

    public WalkerDto? GetById(int id)
    {
        var w = _context.Walkers.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        return w == null ? null : new WalkerDto
        {
            Id = w.Id,
            FullName = w.FullName,
            PhoneNumber = w.PhoneNumber,
            IsAvailable = w.IsAvailable
        };
    }

    public void Create(WalkerDto dto)
    {
        var walker = new Walker
        {
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber,
            IsAvailable = dto.IsAvailable
        };

        _context.Walkers.Add(walker);
        _context.SaveChanges();
    }

    public void Update(WalkerDto dto)
    {
        var walker = _context.Walkers.FirstOrDefault(w => w.Id == dto.Id);
        if (walker == null) return;

        walker.FullName = dto.FullName;
        walker.PhoneNumber = dto.PhoneNumber;
        walker.IsAvailable = dto.IsAvailable;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var walker = _context.Walkers.FirstOrDefault(w => w.Id == id);
        if (walker == null) return;

        walker.IsDeleted = true;
        _context.SaveChanges();
    }

    public List<WalkerDto> Search(string term)
    {
        return _context.Walkers
            .Where(w => !w.IsDeleted && w.FullName.Contains(term))
            .Select(w => new WalkerDto
            {
                Id = w.Id,
                FullName = w.FullName,
                PhoneNumber = w.PhoneNumber,
                IsAvailable = w.IsAvailable
            }).ToList();
    }
}
