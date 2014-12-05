using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using WorkingWithListviewPerf.iOS;
using WorkingWithListviewPerf;

[assembly: ExportRenderer (typeof (NativeListView), typeof (FasterListViewRenderer))]

namespace WorkingWithListviewPerf.iOS
{
	public class FasterListViewRenderer : ViewRenderer<NativeListView, UITableView>
	{
		public FasterListViewRenderer ()
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

				var s = new FasterListViewSource (e.NewElement);
				Control.Source = s;
			}
		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == NativeListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource
				var s = new FasterListViewSource (Element);
				Control.Source = s;
			}
		}
		public override SizeRequest GetDesiredSize (double widthConstraint, double heightConstraint)
		{
			return Control.GetSizeRequest (widthConstraint, heightConstraint, 44, 44);
		}
	}
}

