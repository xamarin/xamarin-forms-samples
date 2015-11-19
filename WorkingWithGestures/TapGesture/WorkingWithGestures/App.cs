using System;
using Xamarin.Forms;

namespace WorkingWithGestures
{
	public class App : Application // superclass new in 1.3
	{
		public App ()
		{
			var tabs = new TabbedPage ();

			// demonstrates an Image tap (and changing the image)
			tabs.Children.Add (new TapInsideImage {Title = "Image", Icon = "csharp.png" });

			// demonstrates adding GestureRecognizer to a Frame
			tabs.Children.Add ( new TapInsideFrame {Title = "Frame", Icon = "csharp.png" });

			// demonstrates using Xaml, Command and databinding
			tabs.Children.Add (new TapInsideFrameXaml {Title = "In Xaml", Icon = "xaml.png" });

			MainPage = tabs;
		}
	}
}

