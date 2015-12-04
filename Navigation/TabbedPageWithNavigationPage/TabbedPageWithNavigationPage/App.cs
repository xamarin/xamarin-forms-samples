using Xamarin.Forms;

namespace TabbedPageWithNavigationPage
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new TabbedPageWithNavigationPage.MainPage ();
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

