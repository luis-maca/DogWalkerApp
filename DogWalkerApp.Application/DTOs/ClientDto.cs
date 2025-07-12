namespace DogWalkerApp.Application.DTOs;

public class ClientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public bool HasActiveSubscription { get; set; }
    public int MaxDogsAllowed { get; set; }
    public int DogCount { get; set; }
}
