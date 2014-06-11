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
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using MobileCRM.Services;

namespace MobileCRM.Helpers
{
    public class AddressToStringConverter : IValueConverter
	{
        #region IValueConverter implementation
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine(value.ToString(), new []{ "AddressToStringConverter.Convert"});
            return ((Address)value).ToString();
        }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
	}

}
