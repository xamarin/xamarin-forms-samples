using System.Reflection;
using Xamarin.Forms;

namespace WorkingWithImages
{
	public class EmbeddedImages : ContentPage
	{
		public EmbeddedImages ()
		{
			var embeddedImage = new Image { Aspect = Aspect.AspectFit };

			// resource identifiers start with assembly-name DOT filename
			embeddedImage.Source = ImageSource.FromResource ("WorkingWithImages.beach.jpg", typeof(EmbeddedImages).GetTypeInfo().Assembly);

			Content = new StackLayout {
				Children = {
					new Label {
						Text = "Image Embedded Resource C#",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center
                    },
					embeddedImage, 
					new Label { Text = "This image is an embedded resource, referenced in C#. The same image file is used, regardless of the pixel density of the device (eg. iOS Retina)." }
				},
				Margin = new Thickness (20, 35, 20, 20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			// NOTE: use for debugging, not in released app code!
			//var assembly = typeof(EmbeddedImages).GetTypeInfo().Assembly;
			//foreach (var res in assembly.GetManifestResourceNames()) 
			//	System.Diagnostics.Debug.WriteLine("found resource: " + res);
		}
	}
}
