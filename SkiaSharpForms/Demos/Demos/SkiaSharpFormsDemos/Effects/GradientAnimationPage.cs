using System;
using System.Diagnostics;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
    public class GradientAnimationPage : ContentPage
    {
        SKCanvasView canvasView;
        bool isAnimating;
        double angle;
        Stopwatch stopwatch = new Stopwatch();

        public GradientAnimationPage()
        {
            Title = "Gradient Animation";

            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            isAnimating = true;
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            stopwatch.Stop();
            isAnimating = false;
        }

        bool OnTimerTick()
        {
            const int duration = 3000;
            angle = 2 * Math.PI * (stopwatch.ElapsedMilliseconds % duration) / duration;
            canvasView.InvalidateSurface();

            return isAnimating;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                SKPoint center = new SKPoint(info.Rect.MidX, info.Rect.MidY);
                int radius = Math.Min(info.Width, info.Height) / 2;
                SKPoint corner = new SKPoint((float)(radius * Math.Cos(angle)),
                                             (float)(radius * Math.Sin(angle)));
                SKPoint upperLeft = center - corner;
                SKPoint lowerRight = center + corner;
                /*
                                // Create liner gradient from upper-left to lower-right
                                paint.Shader = SKShader.CreateLinearGradient(upperLeft,
                                                                             lowerRight,
                                                                             new SKColor[] { SKColors.White, SKColors.Black },
                                                                             new float[] { 0, 1 },
                                                                             SKShaderTileMode.Mirror);
                */



                // Or this, using a transform:

                paint.Shader = SKShader.CreateLinearGradient(new SKPoint(0, 0),
                                                             info.Width < info.Height ? 
                                                                new SKPoint(info.Width, 0) : new SKPoint(0, info.Height),
                                                             new SKColor[] { SKColors.White, SKColors.Black },
                                                             new float[] { 0, 1 },
                                                             SKShaderTileMode.Mirror,
                                                             SKMatrix.MakeRotation((float)angle, info.Rect.MidX, info.Rect.MidY));




                // Draw the gradient on the canvas
                canvas.DrawRect(info.Rect, paint);
            }
        }
    }
}
