using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsGallery.Support
{
	public class NamedColorBuilder : IMarkupExtension
	{
		public string Name { get; set; }

		public Color Color { get; set; }

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			return new NamedColor( Name, Color );
		}
	}
}