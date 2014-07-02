using System;
using Xamarin.Forms;

namespace WorkingWithFiles
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new LoadResourceText ();

//			return new LoadResourceXml ();

//			return new SaveAndLoadText ();
		}
	}
}

