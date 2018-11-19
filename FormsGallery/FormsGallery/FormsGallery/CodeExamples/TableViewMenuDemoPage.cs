using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class TableViewMenuDemoPage : ContentPage
    {
        public TableViewMenuDemoPage()
        {
            Label header = new Label
            {
                Text = "TableView for a menu",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            TableView tableView = new TableView
            {
                Intent = TableIntent.Menu,
                Root = new TableRoot
                {
                    new TableSection("Views for Presentation")
                    {
                        new TextCell
                        {
                            Text = "Label",
                            Detail = "Display a text string",
                            Command = new Command(async () => 
                                await Navigation.PushAsync(new LabelDemoPage()))
                        },

                        new TextCell
                        {
                            Text = "Image",
                            Detail = "Display a bitmap",
                            Command = new Command(async () => 
                                await Navigation.PushAsync(new ImageDemoPage()))
                        },

                        new TextCell
                        {
                            Text = "BoxView",
                            Detail = "Display a colored rectangle",
                            Command = new Command(async () => 
                                await Navigation.PushAsync(new BoxViewDemoPage()))
                        },

                        new TextCell
                        {
                            Text = "WebView",
                            Detail = "Display a Web site",
                            Command = new Command(async () => 
                                await Navigation.PushAsync(new WebViewDemoPage()))
                        },
                    }
                },

                Margin = new Thickness(10, 0)
            };

            // Build the page.
            Title = "TableView Menu Demo";
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
