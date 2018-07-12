using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSShadowEffectPageCS : ContentPage
    {
        public iOSShadowEffectPageCS()
        {
            var boxView = new BoxView { Color = Color.Aqua, WidthRequest = 100, HeightRequest = 100 };
            boxView.On<iOS>()
                   .SetIsShadowEnabled(true)
                   .SetShadowColor(Color.Purple)
                   .SetShadowOffset(new Size(10,10))
                   .SetShadowOpacity(0.7)
                   .SetShadowRadius(12);

            var toggleButton = new Button { Text = "Toggle Shadow Effect" };
            toggleButton.Clicked += (sender, e) => boxView.On<iOS>().SetIsShadowEnabled(!boxView.On<iOS>().GetIsShadowEnabled());

            Title = "Shadow Effect";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = { boxView, toggleButton }
            };
        }
    }
}
