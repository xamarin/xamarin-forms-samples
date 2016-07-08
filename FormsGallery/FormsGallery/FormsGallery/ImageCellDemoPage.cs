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
				FontSize = 50,
				FontAttributes = FontAttributes.Bold,
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
                                Device.OnPlatform(ImageSource.FromUri(new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png")),
                                                  ImageSource.FromFile("ide_xamarin_studio.png"),
                                                  ImageSource.FromFile("Images/ide-xamarin-studio.png")),
                            Text = "This is an ImageCell",
                            Detail = "This is some detail text",
                        }
                    }
                }
            };

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
