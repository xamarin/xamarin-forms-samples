using System;
using System.Globalization;
using Xamarin.Forms;

namespace GridDemos.Converters
{
    public class DoubleToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strParam = parameter as string;
            double multiplier = 1;

            if (!string.IsNullOrEmpty(strParam))
            {
                Double.TryParse(strParam, out multiplier);
            }
            return (int)Math.Round((double)value * multiplier);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strParam = parameter as string;
            double divider = 1;

            if (!string.IsNullOrEmpty(strParam))
            {
                Double.TryParse(strParam, out divider);
            }

            return (int)value / divider;
        }
    }
}
