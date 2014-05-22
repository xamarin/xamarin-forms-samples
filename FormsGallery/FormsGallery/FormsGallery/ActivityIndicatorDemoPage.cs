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
                Font = Font.BoldSystemFontOfSize(40),
                HorizontalOptions = LayoutOptions.Center
            };

            ActivityIndicator activityIndicator = new ActivityIndicator
            {
                IsRunning = true,
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
                    activityIndicator
                }
            };
        }
    }
}
