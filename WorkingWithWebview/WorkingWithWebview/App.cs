using Xamarin.Forms;

namespace WorkingWithWebview
{
	public class App : Application
	{
		public App ()
		{
			var tabs = new TabbedPage ();

			tabs.Children.Add (new LocalHtml {Title = "Local" });
			tabs.Children.Add (new LocalHtmlBaseUrl {Title = "BaseUrl" });
			tabs.Children.Add (new WebPage { Title = "Web Page"});
			tabs.Children.Add (new WebAppPage {Title ="External"});

			MainPage = tabs;
		}
	}
}

