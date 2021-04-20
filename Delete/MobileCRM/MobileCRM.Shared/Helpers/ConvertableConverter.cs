using System;
using Xamarin.Forms;
using System.Globalization;
using MobileCRM.Services;
using System.Diagnostics;

namespace MobileCRM.Helpers
{
    public class ConvertableConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine(value.ToString(), new []{"ConvertableConverter.Convert"});
            if ((parameter == null || !(parameter is CurrencyAttribute)))
                return System.Convert.ChangeType(value, targetType);

            return string.Format(culture.NumberFormat, "{0:C}", value);
        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine(value.ToString(), new []{ "ConvertableConverter.ConvertBack"});

            // Handle money in a localization-aware manner.
            if (targetType == typeof(Decimal) && value is string && ((string)value).StartsWith(NumberFormatInfo.CurrentInfo.CurrencySymbol, true, culture)){
                var val = Decimal.Parse((string)value, NumberStyles.Currency);
                return val;
            }
            var result = Convert(value, targetType, parameter, culture);
            return result;
        }

        #endregion
    }
}

