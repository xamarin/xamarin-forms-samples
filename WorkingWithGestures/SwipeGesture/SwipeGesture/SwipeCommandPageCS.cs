using Xamarin.Forms;

namespace SwipeGesture
{
    public class SwipeCommandPageCS : ContentPage
    {
        public SwipeCommandPageCS()
        {
            var boxView = new BoxView { Color = Color.Teal, WidthRequest = 300, HeightRequest = 300, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
            var label = new Label();
            label.SetBinding(Label.TextProperty, "SwipeDirection");

            var leftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left, CommandParameter = "Left" };
            leftSwipeGesture.SetBinding(SwipeGestureRecognizer.CommandProperty, "SwipeCommand");

            var rightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right, CommandParameter = "Right" };
            rightSwipeGesture.SetBinding(SwipeGestureRecognizer.CommandProperty, "SwipeCommand");

            var upSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Up, CommandParameter = "Up" };
            upSwipeGesture.SetBinding(SwipeGestureRecognizer.CommandProperty, "SwipeCommand");

            var downSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Down, CommandParameter = "Down" };
            downSwipeGesture.SetBinding(SwipeGestureRecognizer.CommandProperty, "SwipeCommand");

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
            BindingContext = new SwipeCommandPageViewModel();
        }
    }
}
