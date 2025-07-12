using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.Domain.Entities;

public class Dog : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public  DogBreed Breed { get; set; }

    public int Age { get; set; }

    public string? SpecialCareInstructions { get; set; } = "";

    public int ClientId { get; set; }

    public Client Client { get; set; }

    public ICollection<DogWalkDog> Walks { get; set; } = new List<DogWalkDog>();

}
