using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using MonoTouch.UIKit;
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
				// lets get a reference to the native control
				var nativeTextField = (UITextField)Control;
				// do whatever you want to the UITextField here!
				nativeTextField.BackgroundColor = UIColor.Gray;
				nativeTextField.BorderStyle = UITextBorderStyle.Line;
			}
		}
	}
}

