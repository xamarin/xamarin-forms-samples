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
                            // Some differences with loading images in initial release.
                            ImageSource = 
                                Device.OnPlatform(ImageSource.FromUri(new Uri("http://xamarin.com/images/index/ide-xamarin-studio.png")),
                                                  ImageSource.FromFile("ide_xamarin_studio.png"),
                                                  ImageSource.FromFile("Images/ide-xamarin-studio.png")),
                            Text = "This is an ImageCell",
                            Detail = "This is some detail text",
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
