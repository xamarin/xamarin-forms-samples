using System;
using CoreGraphics;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;


// This ExportRenderer command tells Xamarin.Forms to use this renderer
// instead of the built-in one for this page
[assembly:ExportRenderer(typeof(Forms2Native.MyThirdPage), typeof(Forms2Native.MyThirdPageRenderer))]

namespace Forms2Native
{
	/// <summary>
	/// Render this page using platform-specific UIKit controls
	/// </summary>
	public class MyThirdPageRenderer : PageRenderer
	{
		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			var page = e.NewElement as MyThirdPage;
		
			var hostViewController = ViewController;

			var viewController = new UIViewController ();

			var label = new UILabel (new CGRect(0, 40, 320, 40));
			label.Text = "3 " + page.Heading;
			viewController.View.Add (label);

			hostViewController.AddChildViewController (viewController);
			hostViewController.View.Add (viewController.View);

			viewController.DidMoveToParentViewController (hostViewController);
		}
	}
}

