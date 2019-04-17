using Xamarin.Forms;

namespace MyCompany.Controls
{
    public class HeadingLabel : Label
    {
        public HeadingLabel()
        {
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            FontAttributes = FontAttributes.Bold;
            HorizontalOptions = LayoutOptions.Center;
        }
    }
}
