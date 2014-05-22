using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class LabelDemoPage : ContentPage
    {
        public LabelDemoPage()
        {
            Label header = new Label
            {
                Text = "Label",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            Label label = new Label
            {
                Text =
                    "Xamarin.Forms is a cross-platform natively " +
                    "backed UI toolkit abstraction that allows " +
                    "developers to easily create user interfaces " +
                    "that can be shared across Android, iOS, and " +
                    "Windows Phone.",

                Font = Font.SystemFontOfSize(NamedSize.Large),
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
                    label
                }
            };
        }
    }
}
