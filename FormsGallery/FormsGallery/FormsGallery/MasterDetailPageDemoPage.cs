using System;
using System.Linq;
using Xamarin.Forms;

namespace FormsGallery
{
    class MasterDetailPageDemoPage :  MasterDetailPage
    {
        public MasterDetailPageDemoPage()
        {
            // Assemble an array of NamedColor objects.
            NamedColor[] namedColors = 
                {
                    new NamedColor("Aqua", Color.Aqua),
                    new NamedColor("Black", Color.Black),
                    new NamedColor("Blue", Color.Blue),
                    new NamedColor("Fuschia", Color.Fuschia),
                    new NamedColor("Gray", Color.Gray),
                    new NamedColor("Green", Color.Green),
                    new NamedColor("Lime", Color.Lime),
                    new NamedColor("Maroon", Color.Maroon),
                    new NamedColor("Navy", Color.Navy),
                    new NamedColor("Olive", Color.Olive),
                    new NamedColor("Purple", Color.Purple),
                    new NamedColor("Red", Color.Red),
                    new NamedColor("Silver", Color.Silver),
                    new NamedColor("Teal", Color.Teal),
                    new NamedColor("White", Color.White),
                    new NamedColor("Yellow", Color.Yellow)
                };

            // Create ListView for the master page.
            ListView listView = new ListView
            {
                ItemsSource = namedColors
            };

            // Create the master page with the ListView.
            this.Master = new ContentPage
            {
                Content = listView
            };

            // Create the detail page using NamedColorPage
            this.Detail = new NamedColorPage(true);

            // Define a selected handler for the ListView.
            listView.ItemSelected += (sender, args) =>
                {
                    // Set the BindingContext of the detail page.
                    this.Detail.BindingContext = args.SelectedItem;
                    this.IsPresented = true;
                };

            // Initialize the ListView selection.
            listView.SelectedItem = namedColors[0];
        }
    }
}
