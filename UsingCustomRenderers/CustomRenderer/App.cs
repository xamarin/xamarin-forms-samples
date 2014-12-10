using System;
using Xamarin.Forms;

namespace CustomRenderer
{
	public class App : Application
	{
		public App ()
		{	
//			return new MainPage ();
			MainPage = new MainPageXaml (); // uncomment this to test the Xaml version
		}
	}
}

