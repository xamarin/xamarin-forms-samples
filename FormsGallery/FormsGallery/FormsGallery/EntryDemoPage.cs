using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class EntryDemoPage : ContentPage
    {
        public EntryDemoPage()
        {
            Label header = new Label
            {
                Text = "Entry",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,

                    new Entry
                    {
                        Keyboard = Keyboard.Email,
                        Placeholder = "Enter email address",
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    },

                    new Entry
                    {
                        Keyboard = Keyboard.Text,
                        Placeholder = "Enter password",
                        IsPassword = true,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    },

                    new Entry
                    {
                        Keyboard = Keyboard.Telephone,
                        Placeholder = "Enter phone number",
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
