using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Curves
{
    public class AnalogClockPage : ContentPage
    {
        SKCanvasView canvasView;
        bool pageIsActive;


        // TODO Define path effects and paints and paths here!!!!


        public AnalogClockPage()
        {
            Title = "Analog Clock";

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

                // Circle for hour and minute marks
                SKRect rect = new SKRect(-90, -90, 90, 90);

                // Minute marks
                strokePaint.StrokeWidth = 3;
                strokePaint.PathEffect = SKPathEffect.CreateDash(new float[] { 0, strokePaint.StrokeWidth * 3.14159f }, 0);
                canvas.DrawOval(rect, strokePaint);

                // Hour marks
                strokePaint.StrokeWidth = 6;
                strokePaint.PathEffect = SKPathEffect.CreateDash(new float[] { 0, strokePaint.StrokeWidth * 2.5f * 3.14159f }, 0);
                canvas.DrawOval(rect, strokePaint);

                // Draw hands
                strokePaint.PathEffect = null;
                strokePaint.StrokeWidth = 2;
                DateTime dateTime = DateTime.Now;

                // Hour hand pointing up
                SKPath path = SKPath.ParseSvgPathData("M 0 -60 C   0 -30 20 -30  5 -20 L  5   0" +
                                                              "C   5 7.5 -5 7.5 -5   0 L -5 -20" +
                                                              "C -20 -30  0 -30  0 -60");
                canvas.Save();
                canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2f);
                canvas.DrawPath(path, strokePaint);
                canvas.DrawPath(path, fillPaint);
                canvas.Restore();

                // Minute hand pointing up
                path = SKPath.ParseSvgPathData("M 0 -80 C   0 -75  0 -70  2.5 -60 L  2.5   0" +
                                                       "C   2.5 5 -2.5 5 -2.5   0 L -2.5 -60" +
                                                       "C 0 -70  0 -75  0 -80");

                canvas.Save();
                canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10f);
                canvas.DrawPath(path, strokePaint);
                canvas.DrawPath(path, fillPaint);
                canvas.Restore();

                // Second hand pointing up
                path = SKPath.ParseSvgPathData("M 0 10 L 0 -80");

                canvas.Save();
                canvas.RotateDegrees(6 * dateTime.Second);
                canvas.DrawPath(path, strokePaint);
                canvas.Restore();
            }
        }
    }
}
