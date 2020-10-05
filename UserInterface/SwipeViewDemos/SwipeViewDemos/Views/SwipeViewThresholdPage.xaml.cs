using Xamarin.Forms;

namespace SwipeViewDemos
{
    public partial class SwipeViewThresholdPage : ContentPage
    {
        public SwipeViewThresholdPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            swipeView.Close();
        }
    }
}
