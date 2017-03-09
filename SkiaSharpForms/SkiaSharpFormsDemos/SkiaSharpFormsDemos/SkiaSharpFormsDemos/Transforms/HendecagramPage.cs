using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Transforms
{
    public class HendecagramPage : ContentPage
    {
        Random random = new Random();
        public static readonly SKPath HendecagramPath;

        static HendecagramPage()
        {
            // Create 11-pointed star
            HendecagramPath = new SKPath();
            for (int i = 0; i < 11; i++)
            {
                double angle = 5 * i * 2 * Math.PI / 11;
                SKPoint pt = new SKPoint(100 * (float)Math.Sin(angle),
                                        -100 * (float)Math.Cos(angle));
                if (i == 0)
                {
                    HendecagramPath.MoveTo(pt);
                }
                else
                {
                    HendecagramPath.LineTo(pt);
                }
            }
            HendecagramPath.Close();
        }

        public HendecagramPage()
        {
            Title = "Hendecagram";

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

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Fill;

                for (int i = 0; i < 10; i++)
                {
                    // Set random color
                    byte[] bytes = new byte[4];
                    random.NextBytes(bytes);
                    paint.Color = new SKColor(bytes[0], bytes[1], bytes[2], bytes[3]);

                    // Set random location
                    int x = random.Next(100, info.Width - 100);
                    int y = random.Next(100, info.Height - 100);

                    canvas.Save();
                    canvas.Translate(x, y);
                    canvas.DrawPath(HendecagramPath, paint);
                    canvas.Restore();
                }
            }
        }
    }
}
