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

namespace MobileCRM.Helpers
{
    public class AddressToPositionConverter : IValueConverter
	{
        #region IValueConverter implementation
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine(value.ToString(), new []{"AddressToPositionConverter.Convert"});
            var address = value as Address;
            if (address == null) return null;

            var position = new Position(address.Latitude, address.Longitude);
            return position;
        }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine(value.ToString(), new []{ "AddressToPositionConverter.ConvertBack"});
            throw new NotImplementedException ();
        }
        #endregion
	}

}
