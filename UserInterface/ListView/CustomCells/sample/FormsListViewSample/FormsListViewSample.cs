using System;

using Xamarin.Forms;

namespace FormsListViewSample
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage();
			MainPage.Navigation.PushAsync (new MainViewXaml ());
			MainPage.Navigation.PushAsync (new MainViewCode ());
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

