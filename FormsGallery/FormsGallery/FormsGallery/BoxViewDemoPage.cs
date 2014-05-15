using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class BoxViewDemoPage : ContentPage
    {
        public BoxViewDemoPage()
        {
            Label header = new Label
            {
                Text = "BoxView",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            BoxView boxView = new BoxView
            {
                Color = Color.Accent,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 0);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    boxView
                }
            };
        }
    }
}
