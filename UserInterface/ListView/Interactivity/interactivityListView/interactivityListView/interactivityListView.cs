using System;

using Xamarin.Forms;

namespace interactivityListView
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			//MainPage = new interactiveListViewXaml ();
			MainPage = new NavigationPage();
			MainPage.Navigation.PushAsync (new interactiveListViewXaml ());
			MainPage.Navigation.PushAsync (new interactiveListViewCode ());
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

