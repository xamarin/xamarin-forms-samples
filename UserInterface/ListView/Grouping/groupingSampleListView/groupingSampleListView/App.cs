using System;

using Xamarin.Forms;

namespace GroupingSampleListView
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new NavigationPage(new GroupedListXaml ());

			// uncomment to view the C# version
			//MainPage = new NavigationPage(new GroupedListCode ());
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

