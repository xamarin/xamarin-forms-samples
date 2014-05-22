using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class EntryCellDemoPage : ContentPage
    {
        public EntryCellDemoPage()
        {
            Label header = new Label
            {
                Text = "EntryCell",
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
                        new EntryCell
                        {
                            Label = "EntryCell:",
                            Placeholder = "Type Text Here"
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
