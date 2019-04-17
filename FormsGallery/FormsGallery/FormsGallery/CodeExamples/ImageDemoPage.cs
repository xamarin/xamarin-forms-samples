using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
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
                Source = new UriImageSource
                {
                    Uri = new Uri("https://aka.ms/campus.jpg")
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            Title = "Image Demo";
            Content = new StackLayout
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
