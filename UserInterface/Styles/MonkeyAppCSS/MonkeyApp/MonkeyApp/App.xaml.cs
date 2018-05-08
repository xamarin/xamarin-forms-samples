using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonkeyApp.Views;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace MonkeyApp
{
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();

            var navigationPage = new NavigationPage(new MonkeysPage());
            navigationPage.BarBackgroundColor = Color.LightGray;
            MainPage = navigationPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
