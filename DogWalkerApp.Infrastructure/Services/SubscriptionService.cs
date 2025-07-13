using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalkerApp.Infrastructure.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly DogWalkerDbContext _context;

    public SubscriptionService(DogWalkerDbContext context)
    {
        _context = context;
    }

    public IEnumerable<SubscriptionDto> GetAll()
    {
        return _context.Subscriptions
            .Include(s => s.Client)
            .Where(s => !s.IsDeleted)
            .Select(s => new SubscriptionDto
            {
                Id = s.Id,
                Frequency = s.Frequency,
                MaxDogsAllowed = s.MaxDogsAllowed,
                IsActive = s.IsActive,
                ClientId = s.ClientId,
                ClientName = s.Client.Name
            }).ToList();
    }


    public SubscriptionDto GetById(int id)
    {
        var s = _context.Subscriptions.Include(s => s.Client).FirstOrDefault(s => s.Id == id);
        if (s == null || s.IsDeleted) return null;

        return new SubscriptionDto
        {
            Id = s.Id,
            Frequency = s.Frequency,
            MaxDogsAllowed = s.MaxDogsAllowed,
            IsActive = s.IsActive,
            ClientId = s.ClientId,
            ClientName = s.Client.Name
        };
    }

    public void Create(SubscriptionDto dto)
    {
        var entity = new Subscription
        {
            Frequency = dto.Frequency,
            MaxDogsAllowed = dto.MaxDogsAllowed,
            IsActive = dto.IsActive,
            ClientId = dto.ClientId
        };

        _context.Subscriptions.Add(entity);
        _context.SaveChanges();
    }

    public void Update(SubscriptionDto dto)
    {
        var entity = _context.Subscriptions.Find(dto.Id);
        if (entity == null || entity.IsDeleted) return;

        entity.Frequency = dto.Frequency;
        entity.MaxDogsAllowed = dto.MaxDogsAllowed;
        entity.IsActive = dto.IsActive;
        entity.ClientId = dto.ClientId;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _context.Subscriptions.Find(id);
        if (entity is not null)
        {
            entity.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
