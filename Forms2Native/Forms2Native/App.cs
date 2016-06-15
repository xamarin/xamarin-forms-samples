using System;
using Xamarin.Forms;

namespace Forms2Native
{
	public class App : Application
	{
		public const string NativeNavigationMessage = "Forms2Native.NativeNavigationMessage";

		public App ()
		{
			var mainNav = new NavigationPage (new MyFirstPage ()); 

			MainPage = mainNav;
		}
	}
}