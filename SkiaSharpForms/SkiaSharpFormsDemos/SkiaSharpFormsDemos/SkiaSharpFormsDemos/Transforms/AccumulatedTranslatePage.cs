using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Transforms
{
    public class AccumulatedTranslatePage : ContentPage
    {
        public AccumulatedTranslatePage()
        {
            Title = "Accumulated Translate";

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

            using (SKPaint strokePaint = new SKPaint())
            {
                strokePaint.Color = SKColors.Black;
                strokePaint.Style = SKPaintStyle.Stroke;
                strokePaint.StrokeWidth = 3;
                SKRect rect = new SKRect(0, 0, 250, 250);

                for (int i = 0; i < 20; i++)
                {
                    canvas.DrawRect(rect, strokePaint);
                    canvas.Translate(10, 50);
                }
            }
        }
    }
}