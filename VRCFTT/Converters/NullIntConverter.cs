using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace VRCFTT.Converters;

public class NullIntConverter: IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (double?)value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value != null ? (int?)value : BindingOperations.DoNothing;
    }
}
