using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class DataTemplateConverter : IValueConverter
	{
		public static DataTemplateConverter Instance
		{
			get { return InstanceField; }
		}	static readonly DataTemplateConverter InstanceField = new DataTemplateConverter();

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			var key = string.Concat( value.GetType().Name, "Template" );
			object resource;
			var result = Application.Current.Resources.TryGetValue( key, out resource ) ? DeterimineView( value, resource ) : null;
			return result;
		}

		static object DeterimineView( object source, object resource )
		{
			var template = resource as DataTemplate;
			if ( template != null )
			{
				var result = template.CreateContent() as BindableObject;
				if ( result != null )
				{
					result.BindingContext = source;
					return result;	
				}
			}
			return null;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}
	}
}