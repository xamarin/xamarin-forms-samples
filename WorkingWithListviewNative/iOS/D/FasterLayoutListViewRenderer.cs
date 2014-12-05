using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using WorkingWithListviewPerf.iOS;
using WorkingWithListviewPerf;

[assembly: ExportRenderer (typeof (NativeListView), typeof (FasterLayoutListViewRenderer))]

namespace WorkingWithListviewPerf.iOS
{
	public class FasterLayoutListViewRenderer : ViewRenderer<NativeListView, UITableView>
	{
		public FasterLayoutListViewRenderer ()
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

				var s = new FasterLayoutListViewSource (e.NewElement);
				Control.Source = s;
			}
		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == NativeListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource
				var s = new FasterLayoutListViewSource (Element);

				Control.Source = s;
			}
		}
		public override SizeRequest GetDesiredSize (double widthConstraint, double heightConstraint)
		{
			return Control.GetSizeRequest (widthConstraint, heightConstraint, 44, 44);
		}
	}
}

