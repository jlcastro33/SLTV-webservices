using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartLeopard.Models.Enums
{
    public static class EnumHelper
    {
        public static TEnum ToEnum<TEnum>(string status) where TEnum : struct
        {
            foreach (var enumValue in Enum.GetValues(typeof(TEnum)))
            {
                if (((Enum)enumValue).GetEnumDescription().Equals(status, StringComparison.OrdinalIgnoreCase))
                    return (TEnum) enumValue;
            }
            return default(TEnum); 
        }

        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString()); 
            var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
