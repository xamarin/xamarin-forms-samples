using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using Android.App;
using Android.Views;
using WorkingWithListviewPerf;
using Android.Graphics.Drawables;

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
			} else { // re-use, clear image
				// doesn't seem to help
				//view.FindViewById<ImageView> (Resource.Id.Image).Drawable.Dispose ();
			}

			view.FindViewById<TextView>(Resource.Id.Text1).Text = x.Name;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = x.Category;


			if (view.FindViewById<ImageView> (Resource.Id.Image).Drawable != null) {
				using (var image = view.FindViewById<ImageView> (Resource.Id.Image).Drawable as BitmapDrawable) {
					if (image != null) {
						if (image.Bitmap != null) {
							//image.Bitmap.Recycle ();
							image.Bitmap.Dispose ();
						}
					}
				}
			}

			// HACK: this makes for choppy scrolling I think :-(
			if (!String.IsNullOrWhiteSpace (x.ImageFilename)) {
				context.Resources.GetBitmapAsync (x.ImageFilename).ContinueWith ((t) => {
					var bitmap = t.Result;
					if (bitmap != null) {
						view.FindViewById<ImageView> (Resource.Id.Image).SetImageBitmap (bitmap);
						bitmap.Dispose ();
					}
				});
			} else {
				view.FindViewById<ImageView> (Resource.Id.Image).SetImageBitmap (null);
			}

			return view;
		}
	}
}

