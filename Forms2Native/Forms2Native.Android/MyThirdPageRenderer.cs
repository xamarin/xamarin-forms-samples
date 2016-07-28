using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

// This ExportRenderer command tells Xamarin.Forms to use this renderer
// instead of the built-in one for this page
[assembly:ExportRenderer(typeof(Forms2Native.MyThirdPage), typeof(Forms2Native.MyThirdPageRenderer))]

namespace Forms2Native
{
	/// <summary>
	/// Render this page using platform-specific Android.Views controls
	/// </summary>
	public class MyThirdPageRenderer : PageRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);
		
			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;

			var thirdActivity = new Intent (activity, typeof (MyThirdActivity));
			activity.StartActivity (thirdActivity);
		}
	}
}
