using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace TextToBinary.Avalonia.Converters;

public class BinaryConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string text && targetType.IsAssignableTo(typeof(string)))
            return string.Join(' ', Encoding.UTF8.GetBytes(text).Select(b => System.Convert.ToString(b, 2).PadLeft(8, '0')));

        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return new NotSupportedException();
    }
}