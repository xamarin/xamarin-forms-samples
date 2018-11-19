using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace FormsGallery
{
	[ContentProperty ("Source")]
	public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;

			return ImageSource.FromResource(Source); 
		}
	}
}

