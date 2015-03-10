using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class InverseBoolean : IValueConverter
	{
		public static InverseBoolean Instance
		{
			get { return InstanceField; }
		}	static readonly InverseBoolean InstanceField = new InverseBoolean();

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			var result = !( (bool)value );
			return result;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}
	}
}