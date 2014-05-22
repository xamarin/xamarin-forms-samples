using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class ImageCellDemoPage : ContentPage
    {
        public ImageCellDemoPage()
        {
            Label header = new Label
            {
                Text = "ImageCell",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new ImageCell
                        {
                            ImageSource = new UriImageSource
                            {
                                Uri = new Uri("http://xamarin.com/images/index/ide-xamarin-studio.png")
                            },
                            Text = "This is an ImageCell",
                            Detail = "This is some detail text",
                            Style = TextCellStyle.Vertical
                        }
                    }
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
                    tableView
                }
            };
        }
    }
}
