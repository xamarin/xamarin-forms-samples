using System;
using Xamarin.Forms;

namespace WorkingWithFonts
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var tabs = new TabbedPage ();

			tabs.Children.Add (new FontPageCs {Title = "C#", Icon = "csharp.png" });

			tabs.Children.Add (new FontPageXaml {Title = "Xaml", Icon = "xaml.png" });

			return tabs;
		}
	}
}

