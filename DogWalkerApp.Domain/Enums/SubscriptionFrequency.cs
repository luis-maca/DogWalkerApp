using System.ComponentModel;

namespace DogWalkerApp.Domain.Enums
{
    public enum SubscriptionFrequency
    {
        [Description("Weekly")]
        Weekly = 1,

        [Description("Monthly")]
        Monthly = 2,

        [Description("Yearly")]
        Yearly = 3
    }
}
