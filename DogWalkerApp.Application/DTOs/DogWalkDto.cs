using DogWalkerApp.Domain.Enums;

namespace DogWalkerApp.Application.DTOs
{
    public class DogWalkDto
    {
        public int Id { get; set; }

        public DateTime WalkDate { get; set; }

        public int DurationMinutes { get; set; }

        public int WalkerId { get; set; }
        public string WalkerName { get; set; } = "";

        public List<int> DogIds { get; set; } = new();
        public List<string> DogNames { get; set; } = new();
        public List<string> ClientNames { get; set; } = new();
    }
}
