using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.Domain.Entities;

public class Subscription: BaseEntity
{
    public int Id { get; set; }

    public SubscriptionFrequency Frequency { get; set; }

    public int MaxDogsAllowed { get; set; }

    public bool IsActive { get; set; }

    public int ClientId { get; set; }

    public Client Client { get; set; }

    public ICollection<Payment> Payments { get; set; }
}
