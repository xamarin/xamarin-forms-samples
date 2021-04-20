using Xamarin.Forms;

namespace EffectsDemo
{
    public class HomePageCS : ContentPage
    {
        public HomePageCS()
        {
            var label = new Label
            {
                Text = "Label Shadow Effect",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Color color = Color.Default;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    color = Color.Black;
                    break;
                case Device.Android:
                    color = Color.White;
                    break;
                case Device.UWP:
                    color = Color.Red;
                    break;
            }

            label.Effects.Add(new ShadowEffect
            {
                Radius = 5,
                Color = color,
                DistanceX = 5,
                DistanceY = 5
            });

            Content = new Grid
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    new Label {
                        Text = "Effects Demo",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    label
                }
            };
        }
    }
}
