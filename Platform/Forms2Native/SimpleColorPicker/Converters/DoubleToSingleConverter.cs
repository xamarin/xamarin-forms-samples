using System;
using System.Globalization;
using Xamarin.Forms;

namespace SimpleColorPicker
{
	public class DoubleToSingleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (float)(double)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (double)(float)value;
		}
	}
}
