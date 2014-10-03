using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class ActivityIndicatorDemoPage : ContentPage
    {
        public ActivityIndicatorDemoPage()
        {
            Label header = new Label
            {
                Text = "ActivityIndicator",
                Font = Font.SystemFontOfSize(40, FontAttributes.Bold),
                HorizontalOptions = LayoutOptions.Center
            };

            ActivityIndicator activityIndicator = new ActivityIndicator
            {
                Color = Device.OnPlatform(Color.Black, Color.Default, Color.Default),
                IsRunning = true,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    activityIndicator
                }
            };
        }
    }
}
