using DogWalkerApp.Application.DTOs;
using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Domain.Entities;
using DogWalkerApp.Domain.Enums;
using DogWalkerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalkerApp.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly DogWalkerDbContext _context;

    public PaymentService(DogWalkerDbContext context)
    {
        _context = context;
    }

    public IEnumerable<PaymentDto> GetAll()
    {
        return _context.Payments
            .Include(p => p.Subscription)
            .ThenInclude(s => s.Client)
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                SubscriptionId = p.SubscriptionId,
                SubscriptionClientName = p.Subscription.Client.Name,
                Date = p.Date,
                Amount = p.Amount,
                Method = p.Method,
                Frequency = p.Subscription.Frequency
            })
            .ToList();
    }

    public PaymentDto? GetById(int id)
    {
        var payment = _context.Payments
            .Include(p => p.Subscription)
            .ThenInclude(s => s.Client)
            .FirstOrDefault(p => p.Id == id);

        if (payment == null) return null;

        return new PaymentDto
        {
            Id = payment.Id,
            SubscriptionId = payment.SubscriptionId,
            SubscriptionClientName = payment.Subscription.Client.Name,
            Date = payment.Date,
            Amount = payment.Amount,
            Method = payment.Method
        };
    }

    public void Create(PaymentDto dto)
    {
        var entity = new Payment
        {
            SubscriptionId = dto.SubscriptionId,
            Date = dto.Date,
            Amount = dto.Amount,
            Method = dto.Method
        };

        _context.Payments.Add(entity);
        _context.SaveChanges();
    }

    public void Update(PaymentDto dto)
    {
        var entity = _context.Payments.Find(dto.Id);
        if (entity == null) return;

        entity.Date = dto.Date;
        entity.Amount = dto.Amount;
        entity.Method = dto.Method;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _context.Payments.Find(id);
        if (entity == null) return;

        _context.Payments.Remove(entity);
        _context.SaveChanges();
    }

    public IEnumerable<PaymentDto> Search(string clientName)
    {
        return _context.Payments
            .Include(p => p.Subscription)
            .ThenInclude(s => s.Client)
            .Where(p => p.Subscription.Client.Name.Contains(clientName))
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                SubscriptionId = p.SubscriptionId,
                SubscriptionClientName = p.Subscription.Client.Name,
                Date = p.Date,
                Amount = p.Amount,
                Method = p.Method
            })
            .ToList();
    }
}
