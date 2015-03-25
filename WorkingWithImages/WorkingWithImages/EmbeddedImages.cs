using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;

namespace WorkingWithImages
{
	public class EmbeddedImages : ContentPage
	{
		public EmbeddedImages ()
		{
			var embeddedImage = new Image { Aspect = Aspect.AspectFit };

			// resource identifiers start with assembly-name DOT filename
			embeddedImage.Source = ImageSource.FromResource ("WorkingWithImages.beach.jpg");

			Content = new StackLayout {
				Children = {
					new Label {
						Text = "ImageSource.FromResource",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold
					},
					embeddedImage, 
					new Label { Text = "WorkingWithImages.beach.jpg embedded resource" }
				},
				Padding = new Thickness (0, 20, 0, 0),
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
