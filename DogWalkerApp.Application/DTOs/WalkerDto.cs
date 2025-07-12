namespace DogWalkerApp.Application.DTOs;

public class WalkerDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
}
