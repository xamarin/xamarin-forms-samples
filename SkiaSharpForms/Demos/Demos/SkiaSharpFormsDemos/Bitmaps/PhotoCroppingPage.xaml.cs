using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
	public partial class PhotoCroppingPage : ContentPage
	{
        PhotoCropperCanvasView photoCropper;
        SKBitmap croppedBitmap;

		public PhotoCroppingPage ()
		{
			InitializeComponent ();

            SKBitmap bitmap = BitmapExtensions.LoadBitmapResource(GetType(),
                "SkiaSharpFormsDemos.Media.MountainClimbers.jpg");

            photoCropper = new PhotoCropperCanvasView(bitmap);
            grid.Children.Add(photoCropper);
		}

        void OnDoneButtonClicked(object sender, EventArgs args)
        {
            croppedBitmap = photoCropper.CroppedBitmap;
        }
    }
}