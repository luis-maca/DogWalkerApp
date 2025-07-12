using DogWalkerApp.Domain.Enums;
using DogWalkerApp.Domain.Helpers;

namespace DogWalkerApp.Application.DTOs;

public class SubscriptionDto
{
    public int Id { get; set; }
    public SubscriptionFrequency Frequency { get; set; }
    public int MaxDogsAllowed { get; set; }
    public bool IsActive { get; set; }

    public int ClientId { get; set; }
    public string ClientName { get; set; }

    public string DisplayName =>
    string.IsNullOrWhiteSpace(ClientName)
        ? "N/A"
        : $"{ClientName} - {EnumHelper.GetDescription(Frequency)}";

}
