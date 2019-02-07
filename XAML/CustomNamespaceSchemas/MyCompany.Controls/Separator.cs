using Xamarin.Forms;

namespace MyCompany.Controls
{
    public class Separator : BoxView
    {
        public Separator()
        {
            Color = Color.Gray;
            HeightRequest = 2;
            Opacity = 0.5;
            Margin = new Thickness(0, 10, 0, 10);
        }
    }
}
