namespace DogWalkerApp.Domain.Entities;

public class AppConfiguration : BaseEntity
{
    public int Id { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    public string Description { get; set; }
}
