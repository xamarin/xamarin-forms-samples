using System;
using Xamarin.Forms;

namespace WorkingWithListview
{
	public class App
	{
		/// <summary>
		/// This sample includes both C# and XAML versions of the user interface.
		/// UNCOMMENT the version below that you wish to try
		/// </summary>
		public static Page GetMainPage ()
		{

			// USE C#

            var tabs = new TabbedPage { Title = "Working with ListView" };

			tabs.Children.Add (new BasicListPage {Title="Basic", Icon = "csharp.png" });

			tabs.Children.Add (new UnevenRowsPage {Title="Uneven", Icon = "csharp.png" });

			tabs.Children.Add (new CustomCellPage {Title="Button", Icon = "csharp.png" });

			return tabs;


			// USE XAML

			var tabsXaml = new TabbedPage ();

			tabsXaml.Children.Add (new BasicListXaml {Title="BasicX", Icon = "xaml.png" });

			tabsXaml.Children.Add (new UnevenRowsXaml {Title="UnevenX", Icon = "xaml.png" });

			tabsXaml.Children.Add (new CustomCellXaml {Title="ButtonX", Icon = "xaml.png" });

//			return tabsXaml;
		}
	}
}

