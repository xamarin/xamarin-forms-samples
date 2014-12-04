using System;
using Xamarin.Forms;

namespace Forms2Native
{
	public class App : Application
	{
		public App ()
		{
			var mainNav = new NavigationPage (new MyFirstPage ()); 

			MainPage = mainNav;
		}
	}
}