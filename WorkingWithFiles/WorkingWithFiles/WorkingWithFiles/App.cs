using Xamarin.Forms;

namespace WorkingWithFiles
{
	public class App : Application
	{
		public App ()
		{
			var tabs = new TabbedPage ();

			tabs.Children.Add (new LoadResourceText {Title = "Resource", IconImageSource = "txt.png" });
			tabs.Children.Add (new LoadResourceXml {Title = "Resource", IconImageSource = "xml.png"});
			tabs.Children.Add(new LoadResourceJson { Title = "Resource", IconImageSource = "json.png" });
			tabs.Children.Add (new SaveAndLoadText {Title = "Save/Load", IconImageSource = "saveload.png"});

			MainPage = tabs;
		}
	}
}
