
using System.Globalization;
using System.Windows.Data;

namespace Schulmanager.Converters
{
  internal class DateOnlyToDateTimeConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is DateOnly d) return d.ToDateTime(TimeOnly.MinValue);
      return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is DateTime dt) return DateOnly.FromDateTime(dt);
      return DateOnly.FromDateTime(DateTime.Today);
    }
  }
}
