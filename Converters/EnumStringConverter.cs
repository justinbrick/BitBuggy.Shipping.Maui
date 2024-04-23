using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BitBuggy.Shipping.Maui.Converters;

/// <summary>
/// Converts enumerations to strings and back. 
/// </summary>
internal class EnumStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return " ";
        }

        if (!value.GetType().IsEnum)
        {
            throw new ArgumentException("Converting object must be an enumeration.");
        }

        return ConvertToString((Enum)value);

    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string str || str == " ")
        {
            return null;
        }
        if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            targetType = targetType.GetGenericArguments()[0];
        }

        if (!targetType.IsEnum)
        {
            throw new ArgumentException("Target type must be an enumeration.");
        }

        object result = Enum.Parse(targetType, str.Replace(" ", ""));
        return result;
    }

    public static string ConvertToString(Enum value)
    {
        return string.Join("", value.ToString().Select(c => char.IsUpper(c) ? " " + c : c.ToString())).TrimStart(' ');
    }
}
