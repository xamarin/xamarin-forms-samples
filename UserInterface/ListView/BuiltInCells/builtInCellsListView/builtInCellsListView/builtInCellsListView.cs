using System;

using Xamarin.Forms;

namespace builtInCellsListView
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage ();
			MainPage.Navigation.PushAsync (new ListViewXaml ());
			MainPage.Navigation.PushAsync (new ListViewCode ());
		}

		protected override void OnStart()
		{


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

