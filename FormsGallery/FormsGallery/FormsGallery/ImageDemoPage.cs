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
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            Image image = new Image
            {
                Source = new UriImageSource
                {
                    Uri = new Uri("http://xamarin.com/images/index/ide-xamarin-studio.png")
                },
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

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
