using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using CustomRenderer;
using CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof(NativeCell), typeof(NativeAndroidCellRenderer))]
namespace CustomRenderer.Droid
{
	/// <summary>
	/// This renderer uses a view defined in /Resources/Layout/NativeAndroidCell.axml
	/// as the cell layout
	/// </summary>
	public class NativeAndroidCellRenderer : ViewCellRenderer
	{
		protected override Android.Views.View GetCellCore (Xamarin.Forms.Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
		{
			var x = (NativeCell)item;

			var view = convertView;

			if (view == null) { 
				// no view to re-use, create new
				view = (context as Activity).LayoutInflater.Inflate (Resource.Layout.NativeAndroidCell, null);
			}

			view.FindViewById<TextView> (Resource.Id.Text1).Text = x.Name;
			view.FindViewById<TextView> (Resource.Id.Text2).Text = x.Category;

			// grab the old image and dispose of it
			if (view.FindViewById<ImageView> (Resource.Id.Image).Drawable != null) {
				using (var image = view.FindViewById<ImageView> (Resource.Id.Image).Drawable as BitmapDrawable) {
					if (image != null) {
						if (image.Bitmap != null) {
							image.Bitmap.Dispose ();
						}
					}
				}
			}

			// If a new image is required, display it
			if (!String.IsNullOrWhiteSpace (x.ImageFilename)) {
				context.Resources.GetBitmapAsync (x.ImageFilename).ContinueWith ((t) => {
					var bitmap = t.Result;
					if (bitmap != null) {
						view.FindViewById<ImageView> (Resource.Id.Image).SetImageBitmap (bitmap);
						bitmap.Dispose ();
					}
				}, TaskScheduler.FromCurrentSynchronizationContext ());

			} else {
				// clear the image
				view.FindViewById<ImageView> (Resource.Id.Image).SetImageBitmap (null);
			}

			return view;
		}
	}
}
