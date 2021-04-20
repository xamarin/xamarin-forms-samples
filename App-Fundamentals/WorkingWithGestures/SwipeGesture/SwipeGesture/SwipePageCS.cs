using Xamarin.Forms;

namespace SwipeGesture
{
    public class SwipePageCS : ContentPage
    {
        public SwipePageCS()
        {
            var boxView = new BoxView { Color = Color.Teal, WidthRequest = 300, HeightRequest = 300, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
            var label = new Label { Text = "You swiped: " };

            var leftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            leftSwipeGesture.Swiped += (sender, e) => label.Text = $"You swiped: {e.Direction.ToString()}";
            var rightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
            rightSwipeGesture.Swiped += (sender, e) => label.Text = $"You swiped: {e.Direction.ToString()}";
            var upSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Up };
            upSwipeGesture.Swiped += (sender, e) => label.Text = $"You swiped: {e.Direction.ToString()}";
            var downSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Down };
            downSwipeGesture.Swiped += (sender, e) => label.Text = $"You swiped: {e.Direction.ToString()}";

            boxView.GestureRecognizers.Add(leftSwipeGesture);
            boxView.GestureRecognizers.Add(rightSwipeGesture);
            boxView.GestureRecognizers.Add(upSwipeGesture);
            boxView.GestureRecognizers.Add(downSwipeGesture);

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label { Margin = new Thickness(0,10), Text = "Swipe inside the box with a single finger." },
                    boxView,
                    label
                }
            };
        }
    }
}
