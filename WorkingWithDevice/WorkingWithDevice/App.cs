using System;
using Xamarin.Forms;

namespace WorkingWithPlatformSpecifics
{
		public class App : Application // superclass new in 1.3
		{
			public App ()
			{

				var csTab = new TabbedPage ();

				csTab.Children.Add(new DevicePage {Title = "C#", Icon="csharp.png"});
				csTab.Children.Add(new DevicePageXaml {Title = "Xaml", Icon="xaml.png"});

				MainPage = csTab;

			}

		}
}

