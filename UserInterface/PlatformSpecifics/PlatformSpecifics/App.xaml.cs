using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PlatformSpecifics
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new PlatformSpecificsPage());
			//MainPage = new iOSNavigationPage();
			//MainPage = new WindowsTabbedPage();
			//MainPage = new WindowsNavigationPage();
			//MainPage = new WindowsMasterDetailPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
