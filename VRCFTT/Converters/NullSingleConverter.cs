using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace VRCFTT.Converters;

public class NullSingleConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (double?)value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value != null ? (float?)value : BindingOperations.DoNothing;
    }
}
