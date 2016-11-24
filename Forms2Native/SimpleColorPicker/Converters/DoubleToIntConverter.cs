using System;
using System.Globalization;
using Xamarin.Forms;

namespace SimpleColorPicker
{
	public class DoubleToIntConverter : IValueConverter
	{
		public double Multiplier { get; set; } = 1;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (int)Math.Round(Multiplier * (double)value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (int)value / Multiplier;
		}
	}
}
