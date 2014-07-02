using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CustomRenderer;
using CustomRenderer.Android;

[assembly: ExportRenderer (typeof (MyEntry), typeof (MyEntryRenderer))]

namespace CustomRenderer.Android
{
	class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				// perform initial setup
				// lets get a reference to the native control
				var nativeEditText = (global::Android.Widget.EditText)Control;
				// do whatever you want to the EditText here!

				nativeEditText.SetBackgroundColor (global::Android.Graphics.Color.DarkGray);
			}
		}
	}
}

