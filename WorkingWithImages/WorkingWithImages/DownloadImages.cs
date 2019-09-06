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

			webImage.Source = ImageSource.FromUri(new Uri("https://aka.ms/campus.jpg"));

            // Other examples of how to set the Image Source
            //			webImage.Source = "https://aka.ms/campus.jpg";
            //
            //			webImage.Source = new UriImageSource {
            //				Uri = new Uri("https://aka.ms/campus.jpg"),
            //				CachingEnabled = false
            //			};
            //
            //			webImage.Source = new UriImageSource {
            //				Uri = new Uri("https://aka.ms/campus.jpg"),
            //				CachingEnabled = true,
            //				CacheValidity = new TimeSpan(5,0,0,0)
            //			};

            Content = new StackLayout {
				Children = {
					new Label {
						Text = "Image UriSource C#",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center
                    },
					webImage, 
					new Label { Text = "This image is downloaded from microsoft.com" }
				},
				Margin = new Thickness (20, 35, 20, 20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
        }
    }
}
