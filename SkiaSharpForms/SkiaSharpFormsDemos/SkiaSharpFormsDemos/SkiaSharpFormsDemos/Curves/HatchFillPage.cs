using System;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Curves
{
    public class HatchFillPage : ContentPage
    {
        SKPaint fillPaint = new SKPaint();

        SKPathEffect horz = SKPathEffect.Create2DLine(3, SKMatrix.MakeScale(6, 6));

        SKPathEffect vert = SKPathEffect.Create2DLine(6, 
            Multiply(SKMatrix.MakeRotationDegrees(90), SKMatrix.MakeScale(24, 24)));

        SKPathEffect diag = SKPathEffect.Create2DLine(12, 
            Multiply(SKMatrix.MakeScale(36, 36), SKMatrix.MakeRotationDegrees(45)));

        SKPaint strokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 3,
            Color = SKColors.Black
        };

        public HatchFillPage()
        {
            Title = "Hatch Fill";

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

            using (SKPath roundRectPath = new SKPath())
            {
                roundRectPath.AddRoundedRect(
                    new SKRect(50, 50, info.Width - 50, info.Height - 50), 100, 100);

                fillPaint.PathEffect = horz;
                fillPaint.Color = SKColors.Red;
                canvas.DrawPath(roundRectPath, fillPaint); // .DrawRoundRect(rect, 100, 100, fillPaint);        // replace

                fillPaint.PathEffect = vert;
                fillPaint.Color = SKColors.Blue;
                canvas.DrawPath(roundRectPath, fillPaint); // .DrawRoundRect(rect, 100, 100, fillPaint);        // replace

                fillPaint.PathEffect = diag;
                fillPaint.Color = SKColors.Green;


                //  canvas.DrawRoundRect(rect, 100, 100, fillPaint);


                canvas.Save();
                canvas.ClipPath(roundRectPath);
                canvas.DrawRect(new SKRect(0, 0, info.Width, info.Height), fillPaint); // .DrawPaint(fillPaint);
                canvas.Restore();





                // Outline the path
                canvas.DrawPath(roundRectPath, strokePaint); // .DrawRoundRect(rect, 100, 100, strokePaint);      // replace
            }
        }

        static SKMatrix Multiply(SKMatrix first, SKMatrix second)
        {
            SKMatrix target;
            SKMatrix.Concat(ref target, first, second);
            return target;
        }
    }
}