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

			var tabsCs = new TabbedPage { Title = "Working with ListView" };
			tabsCs.Children.Add (new BasicListPage {Title="Basic", Icon = "csharp.png" });
			tabsCs.Children.Add (new UnevenRowsPage {Title="Uneven", Icon = "csharp.png" });
			tabsCs.Children.Add (new ContextActionsPage {Title="Context", Icon = "csharp.png" });
			tabsCs.Children.Add (new CustomCellPage {Title="Button", Icon = "csharp.png" });
			tabsCs.Children.Add (new HeaderFooterPage {Title="HeadFoot", Icon = "csharp.png" });

			//MainPage = tabsCs;


			// USE XAML - uncomment above or below MainPage line below to use the XAML or C# versions

			var tabsXaml = new TabbedPage ();
			tabsXaml.Children.Add (new BasicListXaml {Title="BasicX", Icon = "xaml.png" });
			tabsXaml.Children.Add (new UnevenRowsXaml {Title="UnevenX", Icon = "xaml.png" });
			tabsXaml.Children.Add (new ContextActionsXaml {Title="ContextX", Icon = "xaml.png" });
			tabsXaml.Children.Add (new CustomCellXaml {Title="ButtonX", Icon = "xaml.png" });
			tabsXaml.Children.Add (new HeaderFooterXaml {Title="HeadFootX", Icon = "xaml.png" });

			MainPage = tabsXaml;

		}
	}
}

