﻿using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.Domain.Entities;

public class Payment : BaseEntity
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public PaymentMethod Method { get; set; }

    public int SubscriptionId { get; set; }

    public Subscription Subscription { get; set; }
}
