using System;
using Xamarin.Forms;

namespace UsingResxLocalization
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			if (Device.OS != TargetPlatform.WinPhone) {
				DependencyService.Get<ILocalize> ().SetLocale ();
				//Resx.AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
			}

			var tabs = new TabbedPage ();

			tabs.Children.Add (new FirstPage {Title = "C#", Icon="csharp.png"});

			tabs.Children.Add (new FirstPageXaml {Title = "Xaml", Icon="xaml.png"});

			return tabs;
		}
	}
}

