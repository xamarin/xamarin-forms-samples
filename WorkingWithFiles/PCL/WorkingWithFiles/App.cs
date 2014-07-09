using System;
using Xamarin.Forms;

namespace WorkingWithFiles
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			//
			// NOTE: uncomment the relevant page that you'd like to test
			//

			return new LoadResourceText ();

//			return new LoadResourceXml ();

//			return new SaveAndLoadText ();
		}
	}
}

