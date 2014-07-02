using System;
using Xamarin.Forms.Platform.Android;
using WorkingWithFonts;
using WorkingWithFonts.Android;
using Xamarin.Forms;
using Android.Widget;
using Android.Graphics;

[assembly: ExportRenderer (typeof (MyLabel), typeof (MyLabelRenderer_Android))]

namespace WorkingWithFonts.Android
{
	public class MyLabelRenderer_Android : LabelRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);

			var label = (TextView)Control; // for example
			Typeface font = Typeface.CreateFromAsset (Forms.Context.Assets, "SF Hollywood Hills.ttf");
			label.Typeface = font;
		}
	}
}

