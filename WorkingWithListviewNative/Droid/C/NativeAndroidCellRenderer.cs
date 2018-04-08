using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using Android.App;
using WorkingWithListviewNative;
using Android.Graphics.Drawables;
using System.Threading.Tasks;
using WorkingWithListviewNative.Droid;

[assembly: ExportRenderer(typeof(NativeCell), typeof(NativeAndroidCellRenderer))]

namespace WorkingWithListviewNative.Droid
{
    /// <summary>
    /// This renderer uses a view defined in /Resources/Layout/NativeAndroidCell.axml
    /// as the cell layout
    /// </summary>
    public class NativeAndroidCellRenderer : ViewCellRenderer
    {
        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {
            var x = (NativeCell)item;

            var view = convertView;

            if (view == null)
            {// no view to re-use, create new
                view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.NativeAndroidCell, null);
            }
            else
            { // re-use, clear image
              // doesn't seem to help
              //view.FindViewById<ImageView> (Resource.Id.Image).Drawable.Dispose ();
            }

            view.FindViewById<TextView>(Resource.Id.Text1).Text = x.Name;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = x.Category;

            // grab the old image and dispose of it
            // TODO: optimize if the image is the *same* and we want to just keep it
            if (view.FindViewById<ImageView>(Resource.Id.Image).Drawable != null)
            {
                using (var image = view.FindViewById<ImageView>(Resource.Id.Image).Drawable as BitmapDrawable)
                {
                    if (image != null)
                    {
                        if (image.Bitmap != null)
                        {
                            //image.Bitmap.Recycle ();
                            image.Bitmap.Dispose();
                        }
                    }
                }
            }

            // If a new image is required, display it
            if (!String.IsNullOrWhiteSpace(x.ImageFilename))
            {
                context.Resources.GetBitmapAsync(x.ImageFilename).ContinueWith((t) =>
                {
                    var bitmap = t.Result;
                    if (bitmap != null)
                    {
                        view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(bitmap);
                        bitmap.Dispose();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

            }
            else
            {
                // clear the image
                view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(null);
            }

            return view;
        }
    }
}

