using System;

using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class App : Application
	{
		public App ()
		{
			var np = new NavigationPage (new Page1()) {Title="Navigation Stack"};

			// The root page of your application
			MainPage = np;
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

