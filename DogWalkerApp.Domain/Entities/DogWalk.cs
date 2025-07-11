namespace DogWalkerApp.Domain.Entities;

public class DogWalk : BaseEntity
{
    public int Id { get; set; }

    public DateTime WalkDate { get; set; }

    public int DurationMinutes { get; set; }

    public int DogId { get; set; }

    public Dog Dog { get; set; }

    public int WalkerId { get; set; }

    public Walker Walker { get; set; }
}
