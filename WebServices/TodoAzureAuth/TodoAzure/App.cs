using System;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace AzureTodo
{
	public class App : Application
	{
		public static MobileServiceClient Client { get; private set; }

		public App ()
		{
			Client = new MobileServiceClient (Constants.ApplicationURL, Constants.ApplicationKey);

			if (Client.CurrentUser == null)
            {
                MainPage = new NavigationPage(new Login());
            }
			else
            {
                MainPage = new NavigationPage(new TodoList());
            }
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
