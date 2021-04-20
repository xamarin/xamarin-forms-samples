using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class CarouselPageDemoPage : CarouselPage
    {
        public CarouselPageDemoPage()
        {
            Title = "CarouselPage Demo";

            ItemsSource = new NamedColor[] 
            {
                new NamedColor("Red", Color.Red),
                new NamedColor("Yellow", Color.Yellow),
                new NamedColor("Green", Color.Green),
                new NamedColor("Aqua", Color.Aqua),
                new NamedColor("Blue", Color.Blue),
                new NamedColor("Purple", Color.Purple)
            };

            ItemTemplate = new DataTemplate(() =>
            {
                return new NamedColorPage(true);
            });
        }
    }
}
