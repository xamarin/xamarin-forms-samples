using System;
using Xamarin.Forms;

namespace WorkingWithListview
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var tabs = new TabbedPage ();

			tabs.Children.Add (new BasicListPage {Title="Basic", Icon = "csharp.png" });

			tabs.Children.Add (new UnevenRowsPage {Title="Uneven", Icon = "csharp.png" });

			tabs.Children.Add (new CustomCellPage {Title="Buttons", Icon = "csharp.png" });

			return tabs;

//			var tabsXaml = new TabbedPage ();
//
//			tabsXaml.Children.Add (new BasicListXaml {Title="BasicX", Icon = "xaml.png" });
//
//			return tabsXaml;
		}
	}
}

