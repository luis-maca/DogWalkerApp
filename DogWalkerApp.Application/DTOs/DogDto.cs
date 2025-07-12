using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.Application.DTOs;

public class DogDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string Notes { get; set; } = "";
    public DogBreed Breed { get; set; }

    public int ClientId { get; set; }
    public string ClientName { get; set; } = "";
}
