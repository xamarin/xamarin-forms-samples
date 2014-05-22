using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class EditorDemoPage : ContentPage
    {
        public EditorDemoPage()
        {
            Label header = new Label
            {
                Text = "Editor",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            Editor editor = new Editor
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    editor
                }
            };
        }
    }
}
