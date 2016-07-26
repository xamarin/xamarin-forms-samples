using System;

using Xamarin.Forms;

namespace twoWayBinding
{
	public class App : Application
	{
		public App ()
		{
			NavigationPage nav = new NavigationPage ();
			// The root page of your application
			MainPage = nav;
			nav.PushAsync (new HomeCode ());
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

