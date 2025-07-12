using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DogWalkerApp.Domain.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription<TEnum>(TEnum value)
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
                return value?.ToString() ?? string.Empty;

            var field = typeof(TEnum).GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }


        public static TEnum[] GetValues<TEnum>() where TEnum : Enum
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }
    }
}
