using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class TextCellDemoPage : ContentPage
    {
        public TextCellDemoPage()
        {
            Label header = new Label
            {
                Text = "TextCell",
                Font = Font.SystemFontOfSize(50, FontAttributes.Bold),
                HorizontalOptions = LayoutOptions.Center
            };

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new TextCell
                        {
                            Text = "This is a TextCell",
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
