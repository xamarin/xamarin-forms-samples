using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using CustomRenderer;
using CustomRenderer.iOS;

[assembly: ExportRenderer (typeof(MyEntry), typeof(MyEntryRenderer))]
namespace CustomRenderer.iOS
{
	public class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				// do whatever you want to the UITextField here!
				Control.BackgroundColor = UIColor.FromRGB (204, 153, 255);
				Control.BorderStyle = UITextBorderStyle.Line;
			}
		}
	}
}

