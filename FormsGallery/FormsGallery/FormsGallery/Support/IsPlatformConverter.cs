using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class IsPlatformConverter : IValueConverter
	{
		public static IsPlatformConverter Instance
		{
			get { return InstanceField; }
		}	static readonly IsPlatformConverter InstanceField = new IsPlatformConverter();

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			var platform = (TargetPlatform)value;
			var equal = Device.OS == platform;
			var result = parameter == null || !System.Convert.ToBoolean( parameter ) ? equal : !equal;
			return result;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}
	}
}