using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Curves
{
    public class BezierInfinityPage : ContentPage
    {
        public BezierInfinityPage()
        {
            Title = "Bezier Infinity";

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

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);                              // Center 
                path.CubicTo(50, -50, 95, -100, 150, -100);     // To top right
                path.CubicTo(205, -100, 250, -55, 250, 0);      // To right center
                path.CubicTo(250, 55, 205, 100, 150, 100);      // To bottom right
                path.CubicTo(95, 100, 50, 50, 0, 0);            // Back to center
                path.CubicTo(-50, -50, -95, -100, -150, -100);  // To top left
                path.CubicTo(-205, -100, -250, -55, -250, 0);   // To left center
                path.CubicTo(-250, 55, -205, 100, -150, 100);   // To bottom left
                path.CubicTo(-95, 100, -50, 50, 0, 0);          // Back to center
                path.Close();

                SKRect pathBounds = path.Bounds;
                canvas.Translate(info.Width / 2, info.Height / 2);
                canvas.Scale(0.9f * Math.Min(info.Width / pathBounds.Width,
                                             info.Height / pathBounds.Height));

                using (SKPaint paint = new SKPaint())
                {
                    paint.Style = SKPaintStyle.Stroke;
                    paint.Color = SKColors.Blue;
                    paint.StrokeWidth = 5;

                    canvas.DrawPath(path, paint);
                }
            }
        }
    }
}
