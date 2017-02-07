using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos
{
    public class ArchimedeanSpiralPage : ContentPage
    {
        public ArchimedeanSpiralPage()
        {
            Title = "Archimedean Spiral";

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

            SKPoint center = new SKPoint(info.Width / 2, info.Height / 2);
            float radius = Math.Min(center.X, center.Y);

            using (SKPath path = new SKPath())
            {
                for (float angle = 0; angle < 360 /* 0 */ ; angle += 1)
                {
                    float scaledRadius = radius; //  radius * angle / 3600;
                    double radians = Math.PI * angle / 180;
                    float x = info.Width / 2 /* center.X */ + (info.Width / 2) /*  scaledRadius */ * (float)Math.Cos(radians);
                    float y = info.Height / 2 /* center.Y */ + (info.Height / 2) /* scaledRadius */ * (float)Math.Sin(radians);
                    SKPoint point = new SKPoint(x, y);

                    if (angle == 0)
                    {
                        path.MoveTo(point);
                    }
                    else
                    {
                        path.LineTo(point);
                    }
                }

                SKPaint paint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Red,
                    StrokeWidth = 5
                };

                canvas.DrawPath(path, paint);
            }
        }
    }
}
