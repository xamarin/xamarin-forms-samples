using System;
using Xamarin.Forms;
using TablesLists.View;

namespace TablesLists
{
	public static class App
	{
		public static Page GetMainPage ()
		{
			return new NavigationPage(new MainView());
		}
	}
}