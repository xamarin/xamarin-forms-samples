using System;
using Xamarin.Forms;

namespace WorkingWithWebview
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var tabs = new TabbedPage ();

			tabs.Children.Add (new LocalHtml {Title = "Local" });
			tabs.Children.Add (new LocalHtmlBaseUrl {Title = "BaseUrl" });
			tabs.Children.Add (new WebPage { Title = "Web Page"});
			tabs.Children.Add (new WebAppPage {Title ="External"});

			return tabs;
		}
	}
}

