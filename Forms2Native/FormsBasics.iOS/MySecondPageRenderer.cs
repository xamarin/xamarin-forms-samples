using System;
using System.Drawing;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;

// This ExportRenderer command tells Xamarin.Forms to use this renderer
// instead of the built-in one for this page
[assembly:ExportRenderer(typeof(Forms2Native.MySecondPage), typeof(Forms2Native.MySecondPageRenderer))]

namespace Forms2Native
{
	/// <summary>
	/// Render this page using platform-specific UIKit controls
	/// </summary>
	public class MySecondPageRenderer : PageRenderer
	{
		UILabel label;
		String heading;

		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			var page = e.NewElement as MySecondPage;
			var view = NativeView;

			var viewController = ViewController;

			var label = new UILabel (new RectangleF(0, 40, 320, 40));
			label.Text = "2 " + page.Heading;

			view.Add (label);
		}
	}
}

