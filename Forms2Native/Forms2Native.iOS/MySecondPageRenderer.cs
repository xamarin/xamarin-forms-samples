using System;
using CoreGraphics;
using Xamarin.Forms.Platform.iOS;
using UIKit;
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
		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			var page = e.NewElement as MySecondPage;
			var view = NativeView;

			var label = new UILabel (new CGRect (0, 40, 320, 40)) {
				Text = string.Format ("2 {0}", page.Heading)
			};

			view.Add (label);
		}
	}
}

