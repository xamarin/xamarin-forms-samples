using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using System.Collections;
using System.Linq;
using Xamarin.Forms.Platform.Android;
using System.Threading.Tasks;
using Android.Graphics.Drawables;

namespace WorkingWithListviewNative.Droid
{
	/// <summary>
	/// This adapter uses a view defined in /Resources/Layout/NativeAndroidListViewCell.axml
	/// as the cell layout
	/// </summary>
	public class NativeAndroidListViewAdapter : BaseAdapter<DataSource2> {

		readonly Activity context;
		IList<DataSource2> tableItems = new List<DataSource2>();

		public IEnumerable<DataSource2> Items {
			set { 
				tableItems = value.ToList();
			}
		}

		public NativeAndroidListViewAdapter(Activity context, NativeListView2 view)
		{
			this.context = context;
			tableItems = view.Items.ToList();
		}
	
		public override DataSource2 this[int position]
		{
			get
			{ 
				return tableItems[position];
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override int Count
		{
			get { return tableItems.Count; }
		}
			
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = tableItems[position];

			var view = convertView;
			if (view == null) {// no view to re-use, create new
				view = context.LayoutInflater.Inflate (Resource.Layout.NativeAndroidListViewCell, null);
			} else { // re-use, clear image
				// doesn't seem to help
				//view.FindViewById<ImageView> (Resource.Id.Image).Drawable.Dispose ();
			}
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Name;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.Category;

			// grab the old image and dispose of it
			// TODO: optimize if the image is the *same* and we want to just keep it
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

			// If a new image is required, display it
			if (!String.IsNullOrWhiteSpace (item.ImageFilename)) {
				context.Resources.GetBitmapAsync (item.ImageFilename).ContinueWith ((t) => {
					var bitmap = t.Result;
					if (bitmap != null) {
						view.FindViewById<ImageView> (Resource.Id.Image).SetImageBitmap (bitmap);
						bitmap.Dispose ();
					}
				}, TaskScheduler.FromCurrentSynchronizationContext());
			} else {
				// clear the image
				view.FindViewById<ImageView> (Resource.Id.Image).SetImageBitmap (null);
			}

			return view;
		}
	}
}

