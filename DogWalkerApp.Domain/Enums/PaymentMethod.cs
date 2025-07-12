using System.ComponentModel;

namespace DogWalkerApp.Domain.Enums
{
    public enum PaymentMethod
    {
        [Description("Cash")]
        Cash = 1,

        [Description("Card")]
        Card = 2,

        [Description("Bank Transfer")]
        Transfer = 3,

        [Description("Mobile Payment")]
        Mobile = 4
    }
}
