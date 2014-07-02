using System;
using Xamarin.Forms;

namespace UsingDependencyService
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new MainPage();
		}
	}
}

