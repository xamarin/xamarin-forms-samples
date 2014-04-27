using System;
using Xamarin.QuickUI;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Meetum.Views
{
    public class GenericValueConverter : IValueConverter
    {
        Func<object, object> convert;
        Func<object, object> back;

        public GenericValueConverter (Func<object, object> convert, Func<object, object> back = null)
        {
            this.convert = convert;
            this.back = back;
        }

        public object Convert (object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convert (value);
        }

        public object ConvertBack (object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return back (value);
        }
    }

}
