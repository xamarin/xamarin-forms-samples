using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsGallery
{
    class CarouselPageDemoPage : CarouselPage
    {
        public CarouselPageDemoPage()
        {
            this.Title = "CarouselPage";

            this.ItemSource = new NamedColor[] 
            {
                new NamedColor { Name = "Red", Color = Color.Red },
                new NamedColor { Name = "Yellow", Color = Color.Yellow },
                new NamedColor { Name = "Green", Color = Color.Green },
                new NamedColor { Name = "Aqua", Color = Color.Aqua },
                new NamedColor { Name = "Blue", Color = Color.Blue },
                new NamedColor { Name = "Purple", Color = Color.Purple }
            };

            this.ItemTemplate = new DataTemplate(() =>
            {
                return new NamedColorPageTemplate(true);
            });
        }
    }
}
