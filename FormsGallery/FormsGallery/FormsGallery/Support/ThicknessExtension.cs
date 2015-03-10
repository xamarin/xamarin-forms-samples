using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsGallery.Support
{
	[ContentProperty( "Data" )]
	public class ThicknessExtension : IMarkupExtension
	{
		public string Data { get; set; }

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			var parts = Data.Split( new [] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries );
			var result = parts.Length == 2 ? new Thickness( Convert.ToDouble( parts.First() ), Convert.ToDouble( parts.Last() ) ) : new Thickness();
			return result;
		}
	}
}