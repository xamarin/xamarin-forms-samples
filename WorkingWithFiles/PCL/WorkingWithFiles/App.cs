using System;
using Xamarin.Forms;

namespace WorkingWithFiles
{
	public class App : Application // superclass new in 1.3
	{
		public App ()
		{
			var tabs = new TabbedPage ();

			tabs.Children.Add (new LoadResourceText {Title = "Resource", Icon = "txt.png" });

			tabs.Children.Add (new LoadResourceXml {Title = "Resource", Icon = "xml.png"});

			tabs.Children.Add (new SaveAndLoadText {Title = "Save/Load", Icon = "saveload.png"});

			MainPage = tabs;
		}
	}
}

