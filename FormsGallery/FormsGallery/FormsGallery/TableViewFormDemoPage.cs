using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class TableViewFormDemoPage : ContentPage
    {
        public TableViewFormDemoPage()
        {
            Label header = new Label
            {
                Text = "TableView for a form",
                Font = Font.BoldSystemFontOfSize(30),
                HorizontalOptions = LayoutOptions.Center
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
                            Style = TextCellStyle.Vertical
                        },
                        new ImageCell
                        {
                            // Some differences with loading images in initial release.
                            ImageSource = 
                                Device.OnPlatform(ImageSource.FromUri(new Uri("http://xamarin.com/images/index/ide-xamarin-studio.png")),
                                                  ImageSource.FromFile("ide_xamarin_studio.png"),
                                                  ImageSource.FromFile("Images/ide-xamarin-studio.png")),
                            Text = "Image Cell",
                            Detail = "With Detail Text",
                            Style = TextCellStyle.Vertical
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
