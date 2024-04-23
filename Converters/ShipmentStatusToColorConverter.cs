using BitBuggy.Shipping.Maui.Shipping.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuggy.Shipping.Maui.Converters;

class ShipmentStatusToColorConverter : IValueConverter
{
    public static readonly Color BadStateColor = Colors.Red;
    public static readonly Color ReachedStateColor = Colors.Green;
    public static readonly Color UnreachedStateColor = Colors.LightGray;

    public Status DesiredStatus { get; set; }
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Status status && status is not Status.Exception)
        {
            return status >= DesiredStatus ? ReachedStateColor : UnreachedStateColor;
        }
        else
        {
            return BadStateColor;
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
