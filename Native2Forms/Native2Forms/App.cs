using System;
using Xamarin.Forms;

namespace Native2Forms
{
	public class App : Application
	{
		//
		// This page is displayed from within 'native' pages on iOS and Android
		//

		public static Page GetSecondPage ()
		{
			var formsPage = new NavigationPage (new MySecondPage ()); 

			return formsPage;
		}

		public App ()
		{
			MainPage = new NavigationPage (new MySecondPage ());
		}
	}
}