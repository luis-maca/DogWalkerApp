namespace DogWalkerApp.Domain.Entities;

public class Client : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public ICollection<Dog> Dogs { get; set; }

    public Subscription Subscription { get; set; }
}
