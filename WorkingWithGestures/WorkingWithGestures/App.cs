using System;
using Xamarin.Forms;

namespace WorkingWithGestures
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			// demonstrates an Image tap (and changing the image)
			return new TapInsideImage ();

			// demonstrates adding GestureRecognizer to a Frame
//			return new TapInsideFrame ();

			// demonstrates using Xaml, Command and databinding
//			return new TapInsideFrameXaml ();
		}
	}
}

