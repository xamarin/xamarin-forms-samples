using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using WorkingWithListviewNative.iOS;
using WorkingWithListviewNative;

[assembly: ExportRenderer (typeof (NativeListView2), typeof (NativeiOSListViewRenderer))]

namespace WorkingWithListviewNative.iOS
{
	public class NativeiOSListViewRenderer : ViewRenderer<NativeListView2, UITableView>
	{
		public NativeiOSListViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<NativeListView2> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new UITableView ());
			}

			if (e.OldElement != null) {
				// unsubscribe
			}

			if (e.NewElement != null) {
				// subscribe

				var s = new NativeiOSListViewSource (e.NewElement);
				Control.Source = s;
			}
		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == NativeListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource
				var s = new NativeiOSListViewSource (Element);

				Control.Source = s;
			}
		}
		public override SizeRequest GetDesiredSize (double widthConstraint, double heightConstraint)
		{
			return Control.GetSizeRequest (widthConstraint, heightConstraint, 44, 44);
		}
	}
}

