using System;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;
using MobileCRM.Services;

namespace MobileCRM.Helpers
{
    public class UserConverter : IValueConverter
    {
        #region IValueConverter implementation
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new ArgumentOutOfRangeException("targetType", "UserConverter only supports convert to string.");

            if (value == null) return string.Empty;

            Debug.WriteLine(value.ToString(), new []{"OwnerConverter.Convert"});
            return value.ToString();
        }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(IUser))
                throw new ArgumentOutOfRangeException("targetType", "UserConverter only supports convert back from string.");

            if (value == null) return string.Empty;

            Debug.WriteLine(value.ToString(), new []{"OwnerConverter.ConvertBack"});

            Debug.Assert(parameter != null, "The original user should be passed as a converterParameter in the binding definition.");

            return parameter;
        }
        #endregion
    }
}

