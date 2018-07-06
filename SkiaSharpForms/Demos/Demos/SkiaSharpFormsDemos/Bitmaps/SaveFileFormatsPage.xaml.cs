using System;
using System.IO;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
	public partial class SaveFileFormatsPage : ContentPage
	{
        SKBitmap bitmap = BitmapExtensions.LoadBitmapResource(typeof(SaveFileFormatsPage),
            "SkiaSharpFormsDemos.Media.MonkeyFace.png");

		public SaveFileFormatsPage ()
		{
			InitializeComponent ();
		}

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            args.Surface.Canvas.DrawBitmap(bitmap, args.Info.Rect, BitmapStretch.Uniform);
        }

        void OnFormatPickerChanged(object sender, EventArgs args)
        {
            if (formatPicker.SelectedIndex != -1)
            {
                SKEncodedImageFormat imageFormat = (SKEncodedImageFormat)formatPicker.SelectedItem;

                fileNameEntry.Text = Path.ChangeExtension(fileNameEntry.Text, imageFormat.ToString());

                statusLabel.Text = "OK";


          //      fileNameEntry.Text = "Sample." + formatPicker.SelectedItem;
            }
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            SKEncodedImageFormat imageFormat = (SKEncodedImageFormat)formatPicker.SelectedItem;

            System.Diagnostics.Debug.WriteLine(imageFormat);

            //        SKPixmap pixmap = bitmap.PeekPixels();
            //      SKData data = pixmap.Encode(imageFormat, 50);

            using (SKImage image = SKImage.FromBitmap(bitmap))
            using (SKData data = image.Encode(imageFormat, 50))
            {
                if (data == null)
                {
                    statusLabel.Text = "Encode returned null";
                }
                else if (data.IsEmpty)
                {
                    statusLabel.Text = "Encode returned empty array";
                }
                else
                {
                    bool success = await DependencyService.Get<IPhotoLibrary>().
                        SavePhotoAsync(data.ToArray(), folderNameEntry.Text, fileNameEntry.Text);

                    if (!success)
                    {
                        statusLabel.Text = "SavePhotoAsync return false";
                    }
                    else
                    {
                        statusLabel.Text = "Success!";
                    }
                }
            }
        }
    }
}