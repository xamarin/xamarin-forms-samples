using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class DatePickerDemoPage : ContentPage
    {
        public DatePickerDemoPage()
        {
            Label header = new Label
            {
                Text = "DatePicker",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            DatePicker datePicker = new DatePicker
            {
                Format = "D",
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
                    datePicker
                }
            };
        }
    }
}
