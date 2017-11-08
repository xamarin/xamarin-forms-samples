using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class ImageDemoPage : ContentPage
    {
        public ImageDemoPage()
        {
            Label header = new Label
            {
                Text = "Image",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Image image = new Image
            {
                // Some differences with loading images in initial release.
                Source = Device.RuntimePlatform == Device.iOS ? ImageSource.FromUri(new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png")) :
                               Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("ide_xamarin_studio.png") : ImageSource.FromUri(new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png")),

                //Source = new UriImageSource
                //{
                //    Uri = new Uri("http://xamarin.com/images/index/ide-xamarin-studio.png")
                //},
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    image
                }
            };
        }
    }
}
