using System;
using Xamarin.Forms;
using WorkingWithListviewPerf;
using WorkingWithListviewPerf.Droid;
using Xamarin.Forms.Platform.Android;
using System.Collections;
using System.Linq;

[assembly: ExportRenderer (typeof (NativeListView), typeof (FasterLayoutListViewRenderer))]

namespace WorkingWithListviewPerf.Droid
{
	public class FasterLayoutListViewRenderer : ViewRenderer<NativeListView, global::Android.Widget.ListView>
	{
		public FasterLayoutListViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<NativeListView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new global::Android.Widget.ListView (Forms.Context));
				Control.SetBackgroundResource(global::Android.Resource.Color.HoloBlueLight);
			}

			if (e.OldElement != null) {
				// unsubscribe
				Control.ItemClick -= clicked;
			}

			if (e.NewElement != null) {
				// subscribe

				Control.Adapter = new FasterLayoutListViewAdapter (Forms.Context as Android.App.Activity, e.NewElement);
				Control.ItemClick += clicked;
			}
		}

		void clicked (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) {
			Element.NotifyItemSelected (Element.Items.ToList()[e.Position]);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == NativeListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource

				Control.Adapter = new FasterLayoutListViewAdapter (Forms.Context as Android.App.Activity, Element);
			}
		}
	}
}