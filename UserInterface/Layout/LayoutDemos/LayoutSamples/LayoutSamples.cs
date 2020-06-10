using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage {BarBackgroundColor=Color.Green, BarTextColor = Color.White};

			MainPage.Navigation.PushAsync (new ListPage ());
			//MainPage.Navigation.PushAsync (new AbsoluteLayoutDemoCode ());
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

