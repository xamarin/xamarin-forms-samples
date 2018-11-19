using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class BoxViewDemoPage : ContentPage
    {
        public BoxViewDemoPage()
        {
            Label header = new Label
            {
                Text = "BoxView",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
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

            // Build the page.
            Title = "BoxView Demo";
            Content = new StackLayout
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
