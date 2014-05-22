using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class ContentViewDemoPage : ContentPage
    {
        public ContentViewDemoPage()
        {
            Label header = new Label
            {
                Text = "ContentView",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            ContentView contentView = new ContentView
            {
                BackgroundColor = Color.Aqua,
                Padding = new Thickness(25),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "The ContentView (colored aqua in this " +
                           "example) might not seem very useful " +
                           "because it can have a single child " +
                           "(in this example a Label) and doesn't " +
                           "do much else. But ContentView is sometimes a " +
                           "convenient way of providing a background " +
                           "color or giving a little margin to its " +
                           "child through its own Padding property.",
                    TextColor = Color.Purple
                }
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    contentView
                }
            };
        }
    }
}
