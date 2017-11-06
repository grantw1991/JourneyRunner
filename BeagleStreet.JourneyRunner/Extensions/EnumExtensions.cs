using System;
using System.ComponentModel;

namespace BeagleStreet.JourneyRunner.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();

            var descriptionAttribute = Attribute.GetCustomAttribute(type.GetField(Enum.GetName(type, value)), typeof(DescriptionAttribute)) as DescriptionAttribute; 

            if (descriptionAttribute == null)
                throw new Exception("Unable to get value from enum");

            return descriptionAttribute.Description;
        }
    }
}
