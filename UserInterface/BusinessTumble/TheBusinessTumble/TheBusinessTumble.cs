using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TheBusinessTumble
{
	public class App : Application
	{
		public App ()
		{
			var nav = new NavigationPage ();
			nav.BarBackgroundColor = Color.Transparent;
			nav.BarTextColor = Color.White;


			var listpage = new ContentPage();
			listpage.Content = new ListView { ItemsSource = new List<ContentPage> {
					new StackLayoutPage(),
					new AbsoluteLayoutPage(),
					new RelativeLayoutPage()
				}
			};
			((ListView)listpage.Content).ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				nav.PushAsync((ContentPage)e.SelectedItem);
			};
			nav.PushAsync (listpage);

			// The root page of your application
			MainPage = nav;
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

