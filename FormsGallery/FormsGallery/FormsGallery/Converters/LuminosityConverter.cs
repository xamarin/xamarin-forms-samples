
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsGallery.Converters
{
	public static class Defaults
	{
		public static Color Color
		{
			get { return Device.OnPlatform( Color.Black, Color.Default, Color.Default );  }
		}

		public static Font LargeFont
		{
			get { return Font.SystemFontOfSize( NamedSize.Large ); }
		}
	}

	public class NamedColorExtension : IMarkupExtension
	{
		public string Name { get; set; }

		public Color Color { get; set; }

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			return new NamedColor( name, color );
		}
	}

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
