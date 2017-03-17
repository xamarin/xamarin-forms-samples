using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Transforms
{
    public class UglyAnalogClockPage : ContentPage
    {
        SKCanvasView canvasView;
        bool pageIsActive;

        public UglyAnalogClockPage()
        {
            Title = "Ugly Analog Clock";

            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            pageIsActive = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                canvasView.InvalidateSurface();
                return pageIsActive;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            pageIsActive = false;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint strokePaint = new SKPaint())
            using (SKPaint fillPaint = new SKPaint())
            {
                strokePaint.Style = SKPaintStyle.Stroke;
                strokePaint.Color = SKColors.Black;
                strokePaint.StrokeCap = SKStrokeCap.Round;

                fillPaint.Style = SKPaintStyle.Fill;
                fillPaint.Color = SKColors.Gray;

                // Transform for 100-radius circle in center
                canvas.Translate(info.Width / 2, info.Height / 2);
                canvas.Scale(Math.Min(info.Width / 200, info.Height / 200));

                // Tick marks
                for (int angle = 0; angle < 360; angle += 6)
                {
                    canvas.DrawCircle(0, -90, angle % 30 == 0 ? 4 : 2, fillPaint);
                    canvas.RotateDegrees(6);
                }

                DateTime dateTime = DateTime.Now;

                // Hour hand
                strokePaint.StrokeWidth = 20;
                canvas.Save();
                canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2f);
                canvas.DrawLine(0, 0, 0, -60, strokePaint);
                canvas.Restore();

                // Minute hand
                strokePaint.StrokeWidth = 10;
                canvas.Save();
                canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10f);
                canvas.DrawLine(0, 0, 0, -70, strokePaint);
                canvas.Restore();

                // Second hand
                strokePaint.StrokeWidth = 2;
                canvas.Save();
                canvas.RotateDegrees(6 * dateTime.Second);
                canvas.DrawLine(0, 10, 0, -80, strokePaint);
                canvas.Restore();
            }
        }
    }
}
