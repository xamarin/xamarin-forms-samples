using System.Linq;
using CustomRenderer;
using CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof(NativeListView), typeof(NativeAndroidListViewRenderer))]
namespace CustomRenderer.Droid
{
	public class NativeAndroidListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.ListView> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null) {
				// unsubscribe
				Control.ItemClick -= OnItemClick;
			}

			if (e.NewElement != null) {
				// subscribe
				Control.Adapter = new NativeAndroidListViewAdapter (Forms.Context as Android.App.Activity, e.NewElement as NativeListView);
				Control.ItemClick += OnItemClick;
			}
		}

		void OnItemClick (object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{			
			((NativeListView)Element).NotifyItemSelected (((NativeListView)Element).Items.ToList () [e.Position - 1]);
		}
	}
}
