using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSSliderUpdateOnTapPageCS : ContentPage
    {
        public iOSSliderUpdateOnTapPageCS()
        {
            var slider = new Xamarin.Forms.Slider();
            slider.On<iOS>().SetUpdateOnTap(true);

            var button = new Button { Text = "Toggle Update on Tap" };
            button.Clicked += (sender, e) => slider.On<iOS>().SetUpdateOnTap(!slider.On<iOS>().GetUpdateOnTap());;

            Title = "Slider Update on Tap";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label { Text = "Tap on the Slider bar to move the thumb." },
                    slider,
                    button
                }
            };
        }
    }
}
