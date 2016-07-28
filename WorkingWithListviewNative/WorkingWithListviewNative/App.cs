using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;

/*
	REQUIRES XAMARIN.FORMS 1.3
*/
namespace WorkingWithListviewNative
{
	public class App : Application
	{
		public App ()
		{
			var tabs = new TabbedPage ();

			// built-in Xamarin.Forms controls
			tabs.Children.Add (new XamarinFormsPage {Title = "A", Icon = "forms_forms.png"});

			// custom renderer for the list, using a native built-in cell type
			tabs.Children.Add (new NativeListPage {Title = "B", Icon = "native_native.png"});

			// built in Xamarin.Forms list, but with a native cell custom-renderer
			tabs.Children.Add (new XamarinFormsNativeCellPage {Title = "C", Icon = "forms_native.png"});

			// custom renderer for the list, using a native cell that has been custom-defined in native code
			tabs.Children.Add (new NativeListViewPage2 {Title = "D", Icon = "native_native.png"});

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