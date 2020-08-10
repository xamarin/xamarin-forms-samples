using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class MasterDetailPageDemoPage :  MasterDetailPage
    {
        public MasterDetailPageDemoPage ()
        {
            Title = "MasterDetailPage Demo";

            Label header = new Label {
                Text = "MasterDetailPage",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Assemble an array of NamedColor objects.
            NamedColor[] namedColors = {
                new NamedColor ("Aqua", Color.Aqua),
                new NamedColor ("Black", Color.Black),
                new NamedColor ("Blue", Color.Blue),
                new NamedColor ("Fuchsia", Color.Fuchsia),
                new NamedColor ("Gray", Color.Gray),
                new NamedColor ("Green", Color.Green),
                new NamedColor ("Lime", Color.Lime),
                new NamedColor ("Maroon", Color.Maroon),
                new NamedColor ("Navy", Color.Navy),
                new NamedColor ("Olive", Color.Olive),
                new NamedColor ("Purple", Color.Purple),
                new NamedColor ("Red", Color.Red),
                new NamedColor ("Silver", Color.Silver),
                new NamedColor ("Teal", Color.Teal),
                new NamedColor ("White", Color.White),
                new NamedColor ("Yellow", Color.Yellow)
            };

            // Create ListView for the master page.
            ListView listView = new ListView
            {
                ItemsSource = namedColors,
                Margin = new Thickness(10, 0)
            };

            // Create the master page with the ListView.
            Master = new ContentPage {
                Title = "Color List",       // Title required!
                Content = new StackLayout {
                    Children = {
                        header,
                        listView
                    }
                }
            };

            // Create the detail page using NamedColorPage
            NamedColorPage detailPage = new NamedColorPage (true);
            Detail = detailPage;

            // Define a selected handler for the ListView.
            listView.ItemSelected += (sender, args) => {
                // Set the BindingContext of the detail page.
                Detail.BindingContext = args.SelectedItem;

                // Show the detail page.
                IsPresented = false;
            };

            // Initialize the ListView selection.
            listView.SelectedItem = namedColors [0];
        }
    }
}
