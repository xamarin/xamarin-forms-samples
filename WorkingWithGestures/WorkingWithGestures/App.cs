using System;
using Xamarin.Forms;

namespace WorkingWithGestures
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new TapInsideFrame ();

//			return new TapInsideFrameXaml ();
		}
	}
}

