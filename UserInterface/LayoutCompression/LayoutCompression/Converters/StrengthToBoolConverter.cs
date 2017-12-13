using System;
using Xamarin.Forms;

namespace LayoutCompression
{
    public class StrengthToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            int v = (int)value;
            int p = int.Parse((string)parameter);

            return v == p;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false;
        }
    }
}
