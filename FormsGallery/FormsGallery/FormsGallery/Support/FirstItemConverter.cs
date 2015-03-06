using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class FirstItemConverter : IValueConverter
	{
		public static FirstItemConverter Instance
		{
			get { return InstanceField; }
		}	static readonly FirstItemConverter InstanceField = new FirstItemConverter();

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			var enumerable = value as IEnumerable;
			var result = enumerable != null ? enumerable.Cast<object>().FirstOrDefault() : null;
			return result;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}
	}
}