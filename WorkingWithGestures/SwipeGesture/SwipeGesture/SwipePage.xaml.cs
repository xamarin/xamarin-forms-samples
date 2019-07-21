using Xamarin.Forms;

namespace SwipeGesture
{
    public partial class SwipePage : ContentPage
    {
        public SwipePage()
        {
            InitializeComponent();
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            _label.Text = $"You swiped: {e.Direction.ToString()}";
        }
    }
}
