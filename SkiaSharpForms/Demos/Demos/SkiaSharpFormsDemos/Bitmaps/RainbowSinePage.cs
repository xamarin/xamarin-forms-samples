using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
    public class RainbowSinePage : ContentPage
    {
        SKBitmap bitmap;

        public RainbowSinePage()
        {
            Title = "Rainbow Sine";

            bitmap = new SKBitmap(360 * 3, 1024, SKColorType.Bgra8888, SKAlphaType.Unpremul);

            // Create array for the pixel colors
            uint[,] buffer = new uint[bitmap.Height, bitmap.Width];

            // Loop through the rows
            for (int row = 0; row < bitmap.Height; row++)
            {
                // Calculate the sine curve angle and the sine value
                double angle = 2 * Math.PI * row / bitmap.Height;
                double sine = Math.Sin(angle);

                // Loop through the hues
                for (int hue = 0; hue < 360; hue++)
                {
                    // Calculate the column
                    int col = (int)(360 + 360 * sine + hue);

                    // Get the color
                    SKColor color = SKColor.FromHsl(hue, 100, 50);

                    // Store the color value
                    buffer[row, col] = (uint)color;
                }
            }

            unsafe
            {
                fixed (uint* ptr = buffer)
                {
                    bitmap.SetPixels((IntPtr)ptr);
                }
            }

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
            canvas.DrawBitmap(bitmap, info.Rect);
        }
    }
}
