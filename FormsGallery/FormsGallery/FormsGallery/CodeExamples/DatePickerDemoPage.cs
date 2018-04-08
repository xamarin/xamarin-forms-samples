using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class DatePickerDemoPage : ContentPage
    {
        public DatePickerDemoPage()
        {
            Label header = new Label
            {
                Text = "DatePicker",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            DatePicker datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(10, 0)
            };

            // Build the page.
            Title = "DatePicker Demo";
            Content = new StackLayout
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
