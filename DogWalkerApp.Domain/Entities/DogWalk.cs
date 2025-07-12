namespace DogWalkerApp.Domain.Entities;

public class DogWalk : BaseEntity
{
    public int Id { get; set; }

    public DateTime WalkDate { get; set; }

    public int DurationMinutes { get; set; }

    public ICollection<DogWalkDog> Dogs { get; set; } = new List<DogWalkDog>();

    public int WalkerId { get; set; }

    public Walker Walker { get; set; }
}
