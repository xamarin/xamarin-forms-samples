using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class TableViewFormDemoPage : ContentPage
    {
        public TableViewFormDemoPage()
        {
            Label header = new Label
            {
                Text = "TableView for a form",
                FontSize = 30,
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
                Root = new TableRoot("TableView Title")
                {
                    new TableSection("Table Section")
                    {
                        new TextCell
                        {
                            Text = "Text Cell",
                            Detail = "With Detail Text",
                        },
                        new ImageCell
                        {
                            ImageSource = imageSource,
                            Text = "Image Cell",
                            Detail = "With Detail Text",
                        },
                        new SwitchCell
                        {
                            Text = "Switch Cell"
                        },
                        new EntryCell
                        {
                            Label = "Entry Cell",
                            Placeholder = "Type text here"
                        },
                        new ViewCell
                        {
                            View = new Label
                            {
                                Text = "A View Cell can be anything you want!"
                            }
                        }
                    }
                },

                Margin = new Thickness(10, 0)
            };

            // Build the page.
            Title = "TableView Form Demo";
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
