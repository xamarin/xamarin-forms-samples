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


			tabs.Children.Add (new XamarinFormsPage {Title = "A"});

			tabs.Children.Add (new NativeListPage {Title = "B"});

			tabs.Children.Add (new XamarinFormsNativeCellPage {Title = "C"});

			tabs.Children.Add (new NativeListViewPage2 {Title = "D"});


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