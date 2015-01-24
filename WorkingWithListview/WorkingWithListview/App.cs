using System;
using Xamarin.Forms;

namespace WorkingWithListview
{
	/// <summary>
	/// Different ways to customize the ListView control in Xamarin.Forms 1.3
	/// </summary>
	public class App : Application // superclass new in 1.3
	{
		public App ()
		{
			//
			// the code (and xaml) for each page is contained in a separate folder in this project
			//

			// USE C#

            var tabs = new TabbedPage { Title = "Working with ListView" };
			tabs.Children.Add (new BasicListPage {Title="Basic", Icon = "csharp.png" });
			tabs.Children.Add (new UnevenRowsPage {Title="Uneven", Icon = "csharp.png" });
			tabs.Children.Add (new ContextActionsPage {Title="Context", Icon = "csharp.png" });
			tabs.Children.Add (new CustomCellPage {Title="Button", Icon = "csharp.png" });

			MainPage = tabs;


			// USE XAML - uncomment the MainPage line below to use the XAML version

			var tabsXaml = new TabbedPage ();
			tabsXaml.Children.Add (new BasicListXaml {Title="BasicX", Icon = "xaml.png" });
			tabsXaml.Children.Add (new UnevenRowsXaml {Title="UnevenX", Icon = "xaml.png" });
			tabsXaml.Children.Add (new ContextActionsXaml {Title="ContextX", Icon = "xaml.png" });
			tabsXaml.Children.Add (new CustomCellXaml {Title="ButtonX", Icon = "xaml.png" });

			MainPage = tabsXaml;

		}
	}
}

