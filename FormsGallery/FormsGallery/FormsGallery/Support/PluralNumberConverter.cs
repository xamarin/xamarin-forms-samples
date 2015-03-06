using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class PluralNumberConverter : IValueConverter
	{
		public static PluralNumberConverter Instance
		{
			get { return InstanceField; }
		}	static readonly PluralNumberConverter InstanceField = new PluralNumberConverter();

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			var number = (int)value;
			var result = string.Format( parameter as string ?? parameter.ToString(), number, number == 1 ? string.Empty : "s" );
			return result;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}
	}
}