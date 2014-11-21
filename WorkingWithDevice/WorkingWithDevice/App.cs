using System;
using Xamarin.Forms;

namespace WorkingWithPlatformSpecifics
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var csTab = new TabbedPage ();

			csTab.Children.Add(new DevicePage {Title = "C#", Icon="csharp.png"});
			csTab.Children.Add(new DevicePageXaml {Title = "Xaml", Icon="xaml.png"});

			return csTab;

		}
	}
}

