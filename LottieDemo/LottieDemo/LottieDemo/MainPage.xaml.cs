using Xamarin.Forms;
using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace LottieDemo
{
    public partial class MainPage : ContentPage
	{
        public ICommand ClickedCommand { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            playButton.Clicked += (sender, e) => animationView.Play();
            playSegmentsButton.Clicked += (sender, e) => animationView.PlayProgressSegment(0.65f, 0.0f);
            playFramesButton.Clicked += (sender, e) => animationView.PlayFrameSegment(50, 1);
           
            BindingContext = this;

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            animationView.Progress = (float)e.NewValue;
        }

        private void Handle_OnFinish(object sender, System.EventArgs e)
        { }

        private void DisplayAlert(string message)
        { }
    }
}

