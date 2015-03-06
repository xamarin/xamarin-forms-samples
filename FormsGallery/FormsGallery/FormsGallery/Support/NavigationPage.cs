using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsGallery.Support
{
	[ContentProperty( "Root" )] // https://bugzilla.xamarin.com/show_bug.cgi?id=27711
	public class NavigationPage : IMarkupExtension
	{
		public Page Root { get; set; }

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			var result = new Xamarin.Forms.NavigationPage( Root );
			return result;
		}
	}
}