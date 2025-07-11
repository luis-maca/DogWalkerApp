using System.ComponentModel;

namespace DogWalkerApp.Domain.Enums
{
    public enum DogBreed
    {
        [Description("Labrador Retriever")]
        Labrador = 1,

        [Description("Beagle")]
        Beagle = 2,

        [Description("German Shepherd")]
        GermanShepherd = 3,

        [Description("English Bulldog")]
        Bulldog = 4,

        [Description("Poodle")]
        Poodle = 5,

        [Description("Golden Retriever")]
        GoldenRetriever = 6,

        [Description("Siberian Husky")]
        Husky = 7,

        [Description("Chihuahua")]
        Chihuahua = 8,

        [Description("Mixed Breed")]
        Mixed = 99
    }
}
