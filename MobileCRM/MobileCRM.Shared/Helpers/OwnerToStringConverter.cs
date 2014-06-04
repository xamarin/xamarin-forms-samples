using System;
using Xamarin.Forms;
using System.Globalization;

namespace MobileCRM
{
    public class OwnerToStringConverter : IValueConverter
    {
        #region IValueConverter implementation
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
        #endregion
    }
}

