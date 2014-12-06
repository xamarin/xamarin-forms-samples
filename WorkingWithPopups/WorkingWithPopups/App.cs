using System;
using Xamarin.Forms;

namespace WorkingWithPopups
{
	public class App : Application // superclass new in 1.3
	{
		public App ()
		{
			var tabs = new TabbedPage ();
			tabs.Children.Add(new AlertPage { Title = "Alerts", Icon="csharp.png"});
			tabs.Children.Add(new ActionSheetPage {Title = "ActionSheets", Icon="csharp.png"});
			MainPage = tabs;

			//return new ActionSheetPage();
		}
	}
}

