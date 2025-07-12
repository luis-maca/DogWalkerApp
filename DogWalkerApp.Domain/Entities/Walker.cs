namespace DogWalkerApp.Domain.Entities;

public class Walker : BaseEntity
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public bool IsAvailable { get; set; }

    public ICollection<DogWalk> Walks { get; set; }
}
