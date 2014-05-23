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

namespace MobileCRM.iOS.Renderers
{
	[Register ("CustomerDetailsStoryboard")]
	partial class CustomerDetailsStoryboard
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ActiveSwitch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel LabelCustomerCategory { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel LabelCustomerName { get; set; }

		[Action ("UISwitch12_ValueChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void UISwitch12_ValueChanged (UISwitch sender);

		void ReleaseDesignerOutlets ()
		{
			if (ActiveSwitch != null) {
				ActiveSwitch.Dispose ();
				ActiveSwitch = null;
			}
			if (LabelCustomerCategory != null) {
				LabelCustomerCategory.Dispose ();
				LabelCustomerCategory = null;
			}
			if (LabelCustomerName != null) {
				LabelCustomerName.Dispose ();
				LabelCustomerName = null;
			}
		}
	}
}
