using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class LuminosityConverter : IValueConverter
	{
		public static LuminosityConverter Instance
		{
			get { return InstanceField; }
		}	static readonly LuminosityConverter InstanceField = new LuminosityConverter();

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			var luminosity = System.Convert.ToDouble( parameter );
			var result = ( (Color)value ).WithLuminosity( luminosity );
			return result;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}
	}
}
