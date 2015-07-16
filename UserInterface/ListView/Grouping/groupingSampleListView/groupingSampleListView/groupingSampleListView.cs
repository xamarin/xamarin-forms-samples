using System;

using Xamarin.Forms;

namespace groupingSampleListView
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new NavigationPage();
			MainPage.Navigation.PushAsync (new GroupedListXaml ());
			MainPage.Navigation.PushAsync (new GroupedListCode ());
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

