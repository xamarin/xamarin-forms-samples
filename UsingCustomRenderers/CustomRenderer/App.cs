using System;
using Xamarin.Forms;

namespace CustomRenderer
{
	public class App
	{
		public static Page GetMainPage ()
		{	
//			return new MainPage ();
			return new MainPageXaml (); // uncomment this to test the Xaml version
		}
	}
}

