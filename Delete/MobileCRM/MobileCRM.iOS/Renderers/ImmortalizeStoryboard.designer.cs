// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Meetum.iOS.Renderers
{
	[Register ("ImmortalizeStoryboard")]
	partial class ImmortalizeStoryboard
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel LabelCategory { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel LabelName { get; set; }

		[Action ("UIButton2_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void UIButton2_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (LabelCategory != null) {
				LabelCategory.Dispose ();
				LabelCategory = null;
			}
			if (LabelName != null) {
				LabelName.Dispose ();
				LabelName = null;
			}
		}
	}
}
