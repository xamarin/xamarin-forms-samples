using System;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;

namespace MobileCRM
{
    public class UserToStringConverter : IValueConverter
    {
        #region IValueConverter implementation
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            Trace.WriteLine(value, "OwnerToStringConverter.Convert");
            return value.ToString();
        }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            Trace.WriteLine(value, "OwnerToStringConverter.ConvertBack");
            throw new NotImplementedException ();
        }
        #endregion
    }
}

