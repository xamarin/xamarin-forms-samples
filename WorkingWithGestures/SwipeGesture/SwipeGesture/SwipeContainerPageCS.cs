using Xamarin.Forms;

namespace SwipeGesture
{
    public class SwipeContainerPageCS : ContentPage
    {
        public SwipeContainerPageCS()
        {
            var boxView = new BoxView { Color = Color.Teal, WidthRequest = 300, HeightRequest = 300 };
            var label = new Label { Text = "You swiped: " };

            var swipeContainer = new SwipeContainer { Content = boxView, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
            swipeContainer.Swipe += (sender, e) => label.Text = $"You swiped: {e.Direction.ToString()}";

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label { Margin = new Thickness(0,10), Text = "Swipe inside the box with a single finger." },
                    swipeContainer,
                    label
                }
            };
        }
    }
}
