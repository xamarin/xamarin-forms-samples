using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSScrollViewPageCS : MasterDetailPage
    {
        public iOSScrollViewPageCS()
        {
            var scrollView = new Xamarin.Forms.ScrollView();
            var button = new Button { Text = "Toggle ScrollView DelayContentTouches" };
            button.Clicked += (sender, e) => scrollView.On<iOS>().SetShouldDelayContentTouches(!scrollView.On<iOS>().ShouldDelayContentTouches());

            scrollView.Content = new StackLayout
            {
                Margin = new Thickness(0, 20),
                Children = { new Slider(), button }
            };
            scrollView.On<iOS>().SetShouldDelayContentTouches(false);

            Master = new ContentPage { Title = "Menu", BackgroundColor = Color.Blue };
            Detail = new ContentPage { Content = scrollView };
        }
    }
}
