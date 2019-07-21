using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class EntryCellDemoPage : ContentPage
    {
        public EntryCellDemoPage()
        {
            Label header = new Label
            {
                Text = "EntryCell",
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
                        new EntryCell
                        {
                            Label = "EntryCell:",
                            Placeholder = "Type Text Here"
                        }
                    }
                }
            };

            // Build the page.
            Title = "EntryCell Demo";
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
