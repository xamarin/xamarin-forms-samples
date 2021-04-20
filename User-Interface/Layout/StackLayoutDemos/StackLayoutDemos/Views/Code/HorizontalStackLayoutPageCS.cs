using Xamarin.Forms;

namespace StackLayoutDemos.Views
{
    public class HorizontalStackLayoutPageCS : ContentPage
    {
        public HorizontalStackLayoutPageCS()
        {
            Title = "Horizontal StackLayout demo";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    new BoxView { Color = Color.Red },
                    new BoxView { Color = Color.Yellow },
                    new BoxView { Color = Color.Blue },
                    new BoxView { Color = Color.Green },
                    new BoxView { Color = Color.Orange },
                    new BoxView { Color = Color.Purple }
                }
            };
        }
    }
}
