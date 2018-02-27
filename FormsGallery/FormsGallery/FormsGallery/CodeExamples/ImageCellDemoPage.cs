using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
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

            ImageSource imageSource = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    imageSource = ImageSource.FromFile("Icon-Small-40.png");
                    break;

                case Device.Android:
                    imageSource = ImageSource.FromFile("icon.png");
                    break;

                case Device.UWP:
                    imageSource = ImageSource.FromFile("Assets/icon.png");
                    break;
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
                            ImageSource = imageSource,
                            Text = "This is an ImageCell",
                            Detail = "This is some detail text",
                        }
                    }
                }
            };

            // Build the page.
            Title = "ImageCell Demo";
            Padding = new Thickness(10, 0);
            Content = new StackLayout
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
