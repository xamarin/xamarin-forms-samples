using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos
{
    public class Arc : ContentPage
    {
        public Arc()
        {
            Title = "Arc";

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
                path.MoveTo(0, 0);
                path.ArcTo(info.Width / 2, info.Height / 2, info.Width, 0, 300);
       //         path.LineTo(700, 300);

                SKPaint paint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Red,
                    StrokeWidth = 10,

                    StrokeCap = SKStrokeCap.Round,

                    PathEffect = SKPathEffect.CreateDash(new float[] { 0, 30 }, 0)
                };

                canvas.DrawPath(path, paint);


                canvas.DrawLine(info.Width / 2, info.Height / 2, info.Width, 0, paint);
            }
        }
    }
}
