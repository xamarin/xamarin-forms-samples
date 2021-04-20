using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class ActivityIndicatorDemoPage : ContentPage
    {
        public ActivityIndicatorDemoPage()
        {
            Label header = new Label
            {
                Text = "ActivityIndicator",
                FontSize = 40,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            ActivityIndicator activityIndicator = new ActivityIndicator
            {
                IsRunning = true,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            Title = "ActivityIndicator Demo";
            Content = new StackLayout
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
