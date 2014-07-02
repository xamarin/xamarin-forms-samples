using System;
using Xamarin.Forms;

namespace WorkingWithColors
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new ColorDemo ();
//			return new ColorsInXaml ();
		}
	}
}

