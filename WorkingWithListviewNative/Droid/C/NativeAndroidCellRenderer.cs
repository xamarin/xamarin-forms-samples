using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using Android.App;
using Android.Views;
using WorkingWithListviewPerf;

[assembly: ExportRenderer (typeof (NativeCell), typeof (WorkingWithListviewPerf.Droid.NativeAndroidCellRenderer))]

namespace WorkingWithListviewPerf.Droid
{
	/// <summary>
	/// This renderer uses a view defined in /Resources/Layout/NativeAndroidCell.axml
	/// as the cell layout
	/// </summary>
	public class NativeAndroidCellRenderer : ViewCellRenderer
	{
		public NativeAndroidCellRenderer ()
		{
		}

		protected override Android.Views.View GetCellCore (Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
		{
			var x = (NativeCell)item;

			var view = convertView;

			if (view == null) {// no view to re-use, create new
				view = (context as Activity).LayoutInflater.Inflate (Resource.Layout.NativeAndroidCell, null);
			}

			view.FindViewById<TextView>(Resource.Id.Text1).Text = x.Name;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = x.Category;

//			var i = view.Resources.GetIdentifier (item.ImageFilename, "drawable", context.PackageName);
//			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(i);

			// HACK: this makes for choppy scrolling I think :-(
			context.Resources.GetBitmapAsync (x.ImageFilename).ContinueWith((t) => {
				view.FindViewById<ImageView> (Resource.Id.Image).SetImageBitmap (t.Result);
			});

			return view;
		}
	}
}

