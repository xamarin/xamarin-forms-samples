using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace WorkingWithPlatformSpecifics
{
	public class App : Application
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

