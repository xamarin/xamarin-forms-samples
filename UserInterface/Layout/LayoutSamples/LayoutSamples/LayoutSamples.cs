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
			MainPage.Navigation.PushAsync (new MonkeyMoneyXaml ());
			MainPage.Navigation.PushAsync (new MonkeyMusic ());
			MainPage.Navigation.PushAsync (new AbsoluteLayoutDemoXaml ());
			MainPage.Navigation.PushAsync (new RelativeLayoutDemo ());
			MainPage.Navigation.PushAsync (new RelativeLayoutExploration ());
			MainPage.Navigation.PushAsync (new AbsoluteLayoutExplorationCode ());
			MainPage.Navigation.PushAsync (new AbsoluteLayoutExploration ());
			MainPage.Navigation.PushAsync (new GridExploration ());
			MainPage.Navigation.PushAsync (new StackLayoutDemo ());
			MainPage.Navigation.PushAsync (new LabelGridXaml ());
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

