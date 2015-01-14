using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using WorkingWithListviewNative.iOS;
using WorkingWithListviewNative;

[assembly: ExportRenderer (typeof (NativeListView), typeof (NativeListViewRenderer))]

namespace WorkingWithListviewNative.iOS
{
	public class NativeListViewRenderer : ViewRenderer<NativeListView, UITableView>
	{
		public NativeListViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<NativeListView> e)
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

				var s = new NativeListViewSource (e.NewElement);
				Control.Source = s;
			}
		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == NativeListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource
				var s = new NativeListViewSource (Element);
				Control.Source = s;
			}
		}
		public override SizeRequest GetDesiredSize (double widthConstraint, double heightConstraint)
		{
			return Control.GetSizeRequest (widthConstraint, heightConstraint, 44, 44);
		}
	}
}

