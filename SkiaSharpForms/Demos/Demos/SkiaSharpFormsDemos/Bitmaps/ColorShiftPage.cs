using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
	public class ColorShiftPage : ContentPage
	{
        SKBitmap bitmap =
            BitmapExtensions.LoadBitmapResource(typeof(FillRectanglePage),
                                                "SkiaSharpFormsDemos.Media.Banana.jpg");

        public ColorShiftPage ()
		{
            Title = "Color Shift";

            System.Diagnostics.Debug.WriteLine(bitmap.ColorType);

            //     IntPtr pixelsAddr = bitmap.GetPixels();

            SKColor[] colors = bitmap.Pixels;

            for (int i = 0; i < colors.Length; i++)
            {
                SKColor color = colors[i];
                //       colors[i] = new SKColor(color.Green, color.Blue, color.Red);

                //      colors[i] = new SKColor(color.Blue, color.Red, color.Green);


                color.ToHsl(out float hue, out float saturation, out float lightness);

                saturation = Math.Min(100, 1.5f * saturation);

                colors[i] = SKColor.FromHsl(hue, saturation, lightness);




            }

            bitmap.Pixels = colors;



/*
            unsafe
            {
                uint* ptr = (uint*)pixelsAddr.ToPointer();

                for (int i = 0; i < bitmap.ByteCount / 4; i++)
                {
                    uint pixel = *(ptr + i);
                    byte red, green, blue, alpha;

                    if (bitmap.Co)

                    pixel.RgbaGetBytes(out red, out green, out blue, out alpha);

                    pixel = BitmapExtensions.RgbaMakePixel(red, green, 0, alpha);

                    *(ptr + i) = pixel;
                }
            }
*/
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawBitmap(bitmap, info.Rect, BitmapStretch.Uniform);
        }
    }
}