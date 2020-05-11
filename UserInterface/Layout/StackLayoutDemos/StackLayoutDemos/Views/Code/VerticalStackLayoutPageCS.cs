using Xamarin.Forms;

namespace StackLayoutDemos.Views
{
    public class VerticalStackLayoutPageCS : ContentPage
    {
        public VerticalStackLayoutPageCS()
        {
            Title = "Vertical StackLayout demo";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "Primary colors" },
                    new BoxView { Color = Color.Red },
                    new BoxView { Color = Color.Yellow },
                    new BoxView { Color = Color.Blue },
                    new Label { Text = "Secondary colors" },
                    new BoxView { Color = Color.Green },
                    new BoxView { Color = Color.Orange },
                    new BoxView { Color = Color.Purple }
                }
            };
        }
    }
}
