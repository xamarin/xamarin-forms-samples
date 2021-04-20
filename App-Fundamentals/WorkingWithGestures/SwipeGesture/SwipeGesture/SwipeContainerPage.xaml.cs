using Xamarin.Forms;

namespace SwipeGesture
{
    public partial class SwipeContainerPage : ContentPage
    {
        public SwipeContainerPage()
        {
            InitializeComponent();
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            _label.Text = $"You swiped: {e.Direction.ToString()}";
        }
    }
}
