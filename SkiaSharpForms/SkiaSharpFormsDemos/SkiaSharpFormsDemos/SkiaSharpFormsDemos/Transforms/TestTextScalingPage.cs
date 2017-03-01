using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Transforms
{
    public class TestTextScalingPage : ContentPage
    {
        string text = "Is it the same?";

        public TestTextScalingPage()
        {
            Title = "Test Text Scaling";

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
                paint.Color = SKColors.Black;

                // TextSize of 100
                paint.TextSize = 100;
                SKRect bounds = new SKRect();
                paint.MeasureText(text, ref bounds);
                float x = 0;
                float y = -bounds.Top;
                canvas.DrawText(text, 0, y, paint);
                y += bounds.Height; // .Bottom;

                // TextSize of 1 scaled by 100
                paint.TextSize = 1;
            //    paint.MeasureText(text, ref bounds);
            //    y -= bounds.Top;
                canvas.Scale(100, 100, x, y);
                canvas.DrawText(text, 0, y, paint);
            }
        }
    }
}