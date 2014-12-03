using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using WorkingWithListViewPerf.iOS;
using WorkingWithListViewPerf;

[assembly: ExportRenderer (typeof (FasterLayoutListView), typeof (FasterLayoutListViewRenderer))]

namespace WorkingWithListViewPerf.iOS
{
	public class FasterLayoutListViewRenderer : ViewRenderer<FasterLayoutListView, UITableView>
	{
		public FasterLayoutListViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<FasterLayoutListView> e)
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
				var s = new FasterLayoutListViewSource ();
				s.Items = e.NewElement.Items;
				Control.Source = s;
			}
		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == FasterListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource
				var s = new FasterLayoutListViewSource ();
				s.Items = Element.Items;
				Control.Source = s;
			}
		}
		public override SizeRequest GetDesiredSize (double widthConstraint, double heightConstraint)
		{
			return Control.GetSizeRequest (widthConstraint, heightConstraint, 44, 44);
		}
	}
}

