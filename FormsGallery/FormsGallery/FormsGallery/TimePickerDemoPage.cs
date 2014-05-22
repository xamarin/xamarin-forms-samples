using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class TimePickerDemoPage : ContentPage
    {
        public TimePickerDemoPage()
        {
            Label header = new Label
            {
                Text = "TimePicker",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            TimePicker timePicker = new TimePicker
            {
                Format = "T",
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
                    timePicker
                }
            };
        }
    }
}
