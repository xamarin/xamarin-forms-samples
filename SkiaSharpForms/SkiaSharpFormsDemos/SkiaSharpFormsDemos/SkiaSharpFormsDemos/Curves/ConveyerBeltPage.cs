using System;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Curves
{
    public class ConveyerBeltPage : ContentPage
    {
        SKPaint bucketPaint = new SKPaint
        {
            Color = SKColors.Brown,
        };

        SKPath bucketPath = new SKPath();

        public ConveyerBeltPage()
        {
            Title = "Conveyer Belt";

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;

            // Create the path for the bucket
     //       SKRect outer = new SKRect(-linkRadius, -linkRadius, linkRadius, linkRadius);
       //     SKRect inner = outer;
       //     inner.Inflate(-linkThickness, -linkThickness);

//            using (SKPath bucketPath = new SKPath())
            {
                bucketPath.AddRect(new SKRect(-5, -5, 25, 10));

                bucketPath.MoveTo(25, -10);
                bucketPath.LineTo(25, 10);
                bucketPath.ArcTo(100, 100, 0, SKPathArcSize.Small, SKPathDirection.CounterClockwise, 225, 10);
                bucketPath.ArcTo(200, 200, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, 25, 10);

                // Set that path as the 1D path effect for linksPaint
                bucketPaint.PathEffect =
                    SKPathEffect.Create1DPath(bucketPath, 200, 0,
                                              SKPath1DPathEffectStyle.Rotate);
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Black);

            canvas.Translate(100, 200);
            canvas.DrawPath(bucketPath, bucketPaint);

        }
    }
}