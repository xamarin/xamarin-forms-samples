using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using CustomRenderer;
using CustomRenderer.iOS;

[assembly: ExportRenderer (typeof (MyEntry), typeof (MyEntryRenderer))]

namespace CustomRenderer.iOS
{
	public class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				// do whatever you want to the UITextField here!
				Control.BackgroundColor = UIColor.Gray;
				Control.BorderStyle = UITextBorderStyle.Line;
			}
		}
	}
}

