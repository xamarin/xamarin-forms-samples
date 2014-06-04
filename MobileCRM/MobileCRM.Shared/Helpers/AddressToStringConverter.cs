using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using MobileCRM.Shared.CustomViews;
using System.Collections;
using Xamarin.Forms.Maps;
using System.Globalization;

namespace MobileCRM.Shared.Pages
{
    public class AddressToStringConverter<TSource,TResult> : IValueConverter
	{
        #region IValueConverter implementation
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Address)value).ToString();
        }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
        #endregion
	}

}
