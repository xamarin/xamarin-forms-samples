using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkingWithImages
{
    public class DownloadImages : ContentPage
    {
        public DownloadImages() {
			var webImage = new Image { Aspect = Aspect.AspectFit };

			webImage.Source = ImageSource.FromUri(new Uri("http://xamarin.com/content/images/pages/forms/example-app.png"));

			// Other examples of how to set the Image Source
//			webImage.Source = "http://xamarin.com/content/images/pages/forms/example-app.png";
//
//			webImage.Source = new UriImageSource {
//				Uri = new Uri("http://xamarin.com/content/images/pages/forms/example-app.png"),
//				CachingEnabled = false
//			};
//
//			webImage.Source = new UriImageSource {
//				Uri = new Uri("http://xamarin.com/content/images/pages/forms/example-app.png"),
//				CachingEnabled = true,
//				CacheValidity = new TimeSpan(5,0,0,0)
//			};

			Content = new StackLayout {
				Children = {
					new Label {
						Text = "ImageSource.FromUri",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold
					},
					webImage, 
					new Label { Text = "example-app.png gets downloaded from xamarin.com" }
				},
				Padding = new Thickness (0, 20, 0, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
        }
    }
}
