using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Images
{
	public partial class ColorTypesPage : ContentPage
	{
        SKBitmap bitmap;

		public ColorTypesPage ()
		{
			InitializeComponent ();
		}

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            if (bitmap != null)
            {
                float x = (info.Width - bitmap.Width) / 2;
                float y = (info.Height - bitmap.Height) / 2;
                canvas.DrawBitmap(bitmap, x, y);
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            if (colorTypePicker.SelectedIndex != -1)
            {
                SKColorType colorType = (SKColorType)colorTypePicker.SelectedItem;
                SKImageInfo imageInfo = new SKImageInfo(256, 128, colorType);

                System.Diagnostics.Debug.WriteLine(imageInfo.ColorType);


                bitmap = new SKBitmap(imageInfo);



                System.Diagnostics.Debug.WriteLine(bitmap.ColorType);



                using (SKCanvas bitmapCanvas = new SKCanvas(bitmap))
                {
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.Style = SKPaintStyle.Stroke;
                        paint.StrokeWidth = 1;

                        for (int x = 0; x < 256; x++)
                        {
                            paint.Color = new SKColor((byte)x, (byte)x, (byte)x); //  (  SKColor.FromHsl(0.5f, 0.5f, 0.5f); //  (x / 255f, 1, 0.5f);
                            bitmapCanvas.DrawLine(x, 0, x, 127, paint);
                        }
                    }
                }

                canvasView.InvalidateSurface();
            }
        }
    }
}