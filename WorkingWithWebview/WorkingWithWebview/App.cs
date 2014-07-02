using System;
using Xamarin.Forms;

namespace WorkingWithWebview
{
	public class App
	{
		public static Page GetMainPage ()
		{	
//			return new LocalHtml ();
//			return new LocalHtmlBaseUrl ();
			return new WebPage ();

		}
	}
}

