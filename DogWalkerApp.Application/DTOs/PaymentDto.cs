using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.Application.DTOs;

public class PaymentDto
{
    public int Id { get; set; }
    public int SubscriptionId { get; set; }
    public string SubscriptionClientName { get; set; } = string.Empty;
    public SubscriptionFrequency Frequency { get; set; }  // Enum
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public string SubscriptionDisplayName => $"{SubscriptionClientName} - {Frequency}";

}

