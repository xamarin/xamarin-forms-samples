using System;
using Xamarin.Forms;
using System.Reflection;

namespace UsingResxLocalization
{
	public class App : Application
	{
		public App ()
		{
			System.Diagnostics.Debug.WriteLine("===============");
			var assembly = typeof(App).GetTypeInfo().Assembly;
			foreach (var res in assembly.GetManifestResourceNames()) 
				System.Diagnostics.Debug.WriteLine("found resource: " + res);


			if (Device.OS != TargetPlatform.WinPhone) {
				DependencyService.Get<ILocalize> ().SetLocale ();
				//Resx.AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
			}

			var tabs = new TabbedPage ();

			tabs.Children.Add (new FirstPage {Title = "C#", Icon="csharp.png"});

			tabs.Children.Add (new FirstPageXaml {Title = "Xaml", Icon="xaml.png"});

			MainPage = tabs;
		}
	}
}

