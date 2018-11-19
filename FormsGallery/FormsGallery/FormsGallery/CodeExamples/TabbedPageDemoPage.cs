using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class TabbedPageDemoPage : TabbedPage
    {
        public TabbedPageDemoPage()
        {
            Title = "TabbedPage Demo";

            ItemsSource = new NamedColor[] 
            {
                new NamedColor("Red", Color.Red),
                new NamedColor("Green", Color.Green),
                new NamedColor("Blue", Color.Blue),
                new NamedColor("Yellow", Color.Yellow)
            };

            ItemTemplate = new DataTemplate(() => 
            { 
                return new NamedColorPage(false); 
            });
        }
    }
}
