using Xamarin.Forms;

namespace AbsoluteLayoutDemos.Views
{
    public class ProportionalDemoPageCS : ContentPage
    {
        public ProportionalDemoPageCS()
        {
            BoxView blue = new BoxView { Color = Color.Blue };
            AbsoluteLayout.SetLayoutBounds(blue, new Rectangle(0.5, 0, 100, 25));
            AbsoluteLayout.SetLayoutFlags(blue, AbsoluteLayoutFlags.PositionProportional);

            BoxView green = new BoxView { Color = Color.Green };
            AbsoluteLayout.SetLayoutBounds(green, new Rectangle(0, 0.5, 25, 100));
            AbsoluteLayout.SetLayoutFlags(green, AbsoluteLayoutFlags.PositionProportional);

            BoxView red = new BoxView { Color = Color.Red };
            AbsoluteLayout.SetLayoutBounds(red, new Rectangle(1, 0.5, 25, 100));
            AbsoluteLayout.SetLayoutFlags(red, AbsoluteLayoutFlags.PositionProportional);

            BoxView black = new BoxView { Color = Color.Black };
            AbsoluteLayout.SetLayoutBounds(black, new Rectangle(0.5, 1, 100, 25));
            AbsoluteLayout.SetLayoutFlags(black, AbsoluteLayoutFlags.PositionProportional);

            Label label = new Label { Text = "Centered text" };
            AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0.5, 0.5, 110, 25));
            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.PositionProportional);

            Title = "Proportional demo";
            Content = new AbsoluteLayout
            {
                Children =
                {
                    blue,
                    green,
                    red,
                    black,
                    label
                }
            };
        }
    }
}

