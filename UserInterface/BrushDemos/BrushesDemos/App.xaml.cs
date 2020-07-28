using Xamarin.Forms;

namespace BrushesDemos
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Brush_Experimental" });
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
