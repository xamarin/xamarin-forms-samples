using Xamarin.Forms;

namespace DependencyServiceDemos.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.LoadApplication(new DependencyServiceDemos.App());
            DependencyService.Register<ITextToSpeechService, TextToSpeechService>();
        }
    }
}
