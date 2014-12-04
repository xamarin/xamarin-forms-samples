using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace WorkingWithListviewPerf
{
	public class App : Application
	{
		public App ()
		{
			var tabs = new TabbedPage ();


			tabs.Children.Add (new FastPage {Title = "Fast"});

			tabs.Children.Add (new FasterPage {Title = "Faster"});

			tabs.Children.Add (new FasterLayoutPage {Title = "FastLayout"});


			MainPage = tabs;
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