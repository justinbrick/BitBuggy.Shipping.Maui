using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui.Converters;
internal class NullToBoolConverter : IValueConverter
{
    public bool Invert { get; set; } = false;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Invert ? value is null : value is not null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
