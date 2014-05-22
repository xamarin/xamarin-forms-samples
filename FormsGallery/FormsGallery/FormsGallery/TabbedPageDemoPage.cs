using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class TabbedPageDemoPage : TabbedPage
    {
        public TabbedPageDemoPage()
        {
            this.Title = "TabbedPage";

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
                return new NamedColorPageTemplate(false); 
            });
        }
    }
}
