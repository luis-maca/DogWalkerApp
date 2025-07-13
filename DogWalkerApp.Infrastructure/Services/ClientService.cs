using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalkerApp.Infrastructure.Services;

public class ClientService : IClientService
{
    private readonly DogWalkerDbContext _context;

    public ClientService(DogWalkerDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ClientDto> GetAll()
    {
        return _context.Clients
            .Where(c => !c.IsDeleted)
            .Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                HasActiveSubscription = c.Subscription != null && c.Subscription.IsActive,
                MaxDogsAllowed = c.Subscription != null ? c.Subscription.MaxDogsAllowed : 0,
                DogCount = c.Dogs.Count
            })
            .ToList();
    }


    public ClientDto GetById(int id)
    {
        var c = _context.Clients.Find(id);
        if (c == null || c.IsDeleted) return null;

        return new ClientDto
        {
            Id = c.Id,
            Name = c.Name,
            PhoneNumber = c.PhoneNumber,
            Address = c.Address
        };
    }

    public void Create(ClientDto dto)
    {
        var client = new Client
        {
            Name = dto.Name,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address
        };

        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public void Update(ClientDto dto)
    {
        var client = _context.Clients.Find(dto.Id);
        if (client == null || client.IsDeleted) return;

        client.Name = dto.Name;
        client.PhoneNumber = dto.PhoneNumber;
        client.Address = dto.Address;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var client = _context.Clients.Find(id);
        if (client is not null)
        {
            client.IsDeleted = true;
            _context.SaveChanges();
        }
    }

    public IEnumerable<ClientDto> Search(string term)
    {
        term = term.ToLower();

        return _context.Clients
            .Where(c => !c.IsDeleted &&
                (c.Name.ToLower().Contains(term) || c.PhoneNumber.Contains(term)))
            .Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address
            })
            .ToList();
    }


}
