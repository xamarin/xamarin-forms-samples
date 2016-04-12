using System;
using System.Globalization;
using Xamarin.Forms;

namespace EventToCommandBehavior
{
	public class SelectedItemEventArgsToSelectedItemConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			var eventArgs = value as SelectedItemChangedEventArgs;
			return eventArgs.SelectedItem;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}

