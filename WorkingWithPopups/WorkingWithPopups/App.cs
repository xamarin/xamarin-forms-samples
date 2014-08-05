using System;
using Xamarin.Forms;

namespace WorkingWithPopups
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var tabs = new TabbedPage ();
			tabs.Children.Add(new AlertPage { Title = "Alerts", Icon="csharp.png"});
			tabs.Children.Add(new ActionSheetPage {Title = "ActionSheets", Icon="csharp.png"});
			return tabs;

			return new ActionSheetPage();
		}
	}
}

