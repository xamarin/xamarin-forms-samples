using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using WorkingWithListviewPerf.iOS;
using WorkingWithListviewPerf;

[assembly: ExportRenderer (typeof (FasterListView), typeof (FasterListViewRenderer))]

namespace WorkingWithListviewPerf.iOS
{
	public class FasterListViewRenderer : ViewRenderer<FasterListView, UITableView>
	{
		public FasterListViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<FasterListView> e)
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

			if (e.PropertyName == FasterListView.ItemsProperty.PropertyName) {
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

