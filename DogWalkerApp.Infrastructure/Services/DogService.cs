using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Domain.Enums;
using DogWalkerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalkerApp.Infrastructure.Services;

public class DogService : IDogService
{
    private readonly DogWalkerDbContext _context;

    public DogService(DogWalkerDbContext context)
    {
        _context = context;
    }

    public List<DogDto> GetAll()
    {
        return _context.Dogs
            .Include(d => d.Client)
            .Select(d => new DogDto
            {
                Id = d.Id,
                Name = d.Name,
                Age = d.Age,
                Notes = d.SpecialCareInstructions,
                Breed = d.Breed,
                ClientId = d.ClientId,
                ClientName = d.Client.Name
            }).ToList();
    }

    public DogDto? GetById(int id)
    {
        return GetAll().FirstOrDefault(d => d.Id == id);
    }

    public List<DogDto> GetByClientId(int clientId)
    {
        return GetAll().Where(d => d.ClientId == clientId).ToList();
    }

    public void Create(DogDto dto)
    {
        var count = _context.Dogs.Count(d => d.ClientId == dto.ClientId);
        var subscription = _context.Subscriptions
            .FirstOrDefault(s => s.ClientId == dto.ClientId && s.IsActive);

        if (subscription == null)
            throw new InvalidOperationException("Client must have an active subscription.");

        if (count >= subscription.MaxDogsAllowed)
            throw new InvalidOperationException("Client has reached the max number of dogs allowed.");

        var dog = new Dog
        {
            Name = dto.Name,
            Age = dto.Age,
            SpecialCareInstructions = dto.Notes,
            Breed = dto.Breed,
            ClientId = dto.ClientId
        };

        _context.Dogs.Add(dog);
        _context.SaveChanges();
    }

    public void Update(DogDto dto)
    {
        var dog = _context.Dogs.Find(dto.Id);
        if (dog == null) return;

        dog.Name = dto.Name;
        dog.Age = dto.Age;
        dog.SpecialCareInstructions = dto.Notes;
        dog.Breed = dto.Breed;
        dog.ClientId = dto.ClientId;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var dog = _context.Dogs.Find(id);
        if (dog == null) return;

        _context.Dogs.Remove(dog);
        _context.SaveChanges();
    }

    public List<DogDto> Search(string term)
    {
        return GetAll()
            .Where(d => d.Name.ToLower().Contains(term.ToLower())
                     || d.ClientName.ToLower().Contains(term.ToLower()))
            .ToList();
    }
}
