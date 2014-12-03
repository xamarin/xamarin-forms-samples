using System;
using Xamarin.Forms;
using WorkingWithListViewPerf;
using WorkingWithListViewPerf.Droid;
using Xamarin.Forms.Platform.Android;
using System.Collections;

[assembly: ExportRenderer (typeof (FasterListView), typeof (FasterListViewRenderer))]

namespace WorkingWithListViewPerf.Droid
{
	public class FasterListViewRenderer : ViewRenderer<FasterListView, global::Android.Widget.ListView>
	{
		public FasterListViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<FasterListView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new global::Android.Widget.ListView (Forms.Context));
			}

			if (e.OldElement != null) {
				// unsubscribe
			}

			if (e.NewElement != null) {
				// subscribe

				var a =  new FasterListViewAdapter (Forms.Context as Android.App.Activity);
				a.Items = e.NewElement.Items;
				Control.Adapter = a;
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == FasterListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource

				var a =  new FasterListViewAdapter (Forms.Context as Android.App.Activity);
				a.Items = Element.Items;
				Control.Adapter = a;
			}
		}
	}
}