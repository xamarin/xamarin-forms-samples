using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace FormsGallery.Support
{
	[ContentProperty( "Data" )]
	public class PositionExtension : IMarkupExtension
	{
		public string Data { get; set; }

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			var parts = Data.Split( new [] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries );
			var result = parts.Length == 2 ? new Position( Convert.ToDouble( parts.First() ), Convert.ToDouble( parts.Last() ) ) : new Position();
			return result;
		}
	}
}