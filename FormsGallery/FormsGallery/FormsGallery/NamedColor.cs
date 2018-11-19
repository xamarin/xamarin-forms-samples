using Xamarin.Forms;

namespace FormsGallery
{
    // Used in TabbedPageDemoPage, CarouselPageDemoPage & MasterDetailPageDemoPage.
    public class NamedColor
    {
        public NamedColor()
        {
            ;
        }
        public NamedColor(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public string Name { set; get; }

        public Color Color { set; get; }

        public override string ToString()
        {
            return Name;
        }
    }

}
