using System;
using Xamarin.Forms;

namespace CustomRenderer
{
	public class App : Application
	{
		public App ()
		{	
			//MainPage = new MainPage ();   // uncomment this to test the code-behind version
			MainPage = new MainPageXaml (); 
		}
	}
}

