using System;
using Xamarin.Forms;
using WorkingWithListViewPerf;
using WorkingWithListViewPerf.Droid;
using Xamarin.Forms.Platform.Android;
using System.Collections;

[assembly: ExportRenderer (typeof (FasterLayoutListView), typeof (FasterLayoutListViewRenderer))]

namespace WorkingWithListViewPerf.Droid
{
	public class FasterLayoutListViewRenderer : ViewRenderer<FasterLayoutListView, global::Android.Widget.ListView>
	{
		public FasterLayoutListViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<FasterLayoutListView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new global::Android.Widget.ListView (Forms.Context));
				Control.SetBackgroundResource(global::Android.Resource.Color.HoloBlueLight);
			}

			if (e.OldElement != null) {
				// unsubscribe
			}

			if (e.NewElement != null) {
				// subscribe

				var a =  new FasterLayoutListViewAdapter (Forms.Context as Android.App.Activity);
				a.Items = e.NewElement.Items;
				Control.Adapter = a;

			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == FasterListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource

				var a =  new FasterLayoutListViewAdapter (Forms.Context as Android.App.Activity);
				a.Items = Element.Items;
				Control.Adapter = a;
			}
		}
	}
}