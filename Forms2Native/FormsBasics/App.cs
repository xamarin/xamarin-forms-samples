using System;
using Xamarin.Forms;

namespace Forms2Native
{
	public static class App
	{
		public static Page GetMainPage ()
		{
			var mainNav = new NavigationPage (new MyFirstPage ()); 

			return mainNav;
		}
	}
}