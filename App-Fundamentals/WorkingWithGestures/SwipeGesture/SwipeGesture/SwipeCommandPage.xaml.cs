using Xamarin.Forms;

namespace SwipeGesture
{
    public partial class SwipeCommandPage : ContentPage
    {
        public SwipeCommandPage()
        {
            InitializeComponent();
            BindingContext = new SwipeCommandPageViewModel();
        }
    }
}
