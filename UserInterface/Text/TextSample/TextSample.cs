using System;

using Xamarin.Forms;

namespace TextSample
{
	public class App : Application
	{
		Page nav = new NavigationPage();
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage();
			MainPage.Navigation.PushAsync (new ListPage ());
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

