using System;
using System.Diagnostics;
using System.Collections.Generic;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using TouchTracking;

namespace SpinPaint
{
    public partial class MainPage : ContentPage
    {
        SKBitmap bitmap;
        SKCanvas bitmapCanvas;
        int bitmapSize;

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            Color = SKColors.Black
        };

        Stopwatch stopwatch = new Stopwatch();
        float angle;

        class FingerInfo
        {
            public Point ThisPosition;
            public SKPoint LastPosition;
        }

        Dictionary<long, FingerInfo> idDictionary = new Dictionary<long, FingerInfo>();

        public MainPage()
        {
            InitializeComponent();
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    idDictionary.Add(args.Id, new FingerInfo
                    {
                        ThisPosition = args.Location,
                        LastPosition = new SKPoint(float.PositiveInfinity, float.PositiveInfinity)
                    });
                    break;

                case TouchActionType.Moved:
                    idDictionary[args.Id].ThisPosition = args.Location;
                    break;

                case TouchActionType.Released:
                case TouchActionType.Cancelled:
                    idDictionary.Remove(args.Id);
                    break;
            }
        }

        bool OnTimerTick()
        {
            float tColor = stopwatch.ElapsedMilliseconds % 10000 / 10000f;
            paint.Color = SKColor.FromHsl(360 * tColor, 100, 50);
     //       titleLabel.TextColor = paint.Color.ToFormsColor();

            float tAngle = stopwatch.ElapsedMilliseconds % 5000 / 5000f;
            angle = 360 * tAngle;

            SKMatrix matrix = SKMatrix.MakeRotationDegrees(-angle, bitmap.Width / 2, bitmap.Height / 2);

            foreach (long id in idDictionary.Keys)
            {
                FingerInfo fingerInfo = idDictionary[id];

                float factor = canvasView.CanvasSize.Width / (float)canvasView.Width;
                SKPoint convertedPoint = new SKPoint(factor * (float)fingerInfo.ThisPosition.X,
                                                     factor * (float)fingerInfo.ThisPosition.Y);




                //float bitmapSize = Math.Min(canvasView.CanvasSize.Width, canvasView.CanvasSize.Height);
                //float bitmapLeft = canvasView.CanvasSize.Width - bitmapSize;
                //float bitmapTop = canvasView.CanvasSize.Height - bitmapSize;



                SKPoint pt0 = matrix.MapPoint(convertedPoint);

                if (!float.IsPositiveInfinity(fingerInfo.LastPosition.X))
                {
                    SKPoint pt1 = fingerInfo.LastPosition;
                    bitmapCanvas.DrawLine(pt0.X, pt0.Y, pt1.X, pt1.Y, paint);

                    float x0Flip = bitmap.Width - pt0.X;
                    float y0Flip = bitmap.Height - pt0.Y;
                    float x1Flip = bitmap.Width - pt1.X;
                    float y1Flip = bitmap.Height - pt1.Y;

                    bitmapCanvas.DrawLine(x0Flip, pt0.Y, x1Flip, pt1.Y, paint);
                    bitmapCanvas.DrawLine(pt0.X, y0Flip, pt1.X, y1Flip, paint);
                    bitmapCanvas.DrawLine(x0Flip, y0Flip, x1Flip, y1Flip, paint);
                }

                fingerInfo.LastPosition = pt0;
            }

            canvasView.InvalidateSurface();
            return true;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;


            if (bitmap == null)
            {
                bitmapSize = Math.Min(info.Width, info.Height);
                //              int bitmapSize = Math.Min(info.Width, info.Height);
                bitmap = new SKBitmap(bitmapSize, bitmapSize);

                bitmapCanvas = new SKCanvas(bitmap);

                PrepBitmap(bitmapCanvas, bitmapSize);

                // TODO: Figure out if bitmap is now wrong size



            }

            float radius = bitmapSize / 2f;

            canvas.Clear();

            //      int bitmapLeft = info.Width - bitmapSize;
            //    int bitmapTop = info.Height - bitmapSize;

            canvas.RotateDegrees(angle, /* bitmapLeft + */ radius, /* bitmapTop + */ radius);
            canvas.DrawBitmap(bitmap, 0, 0); //  bitmapLeft, bitmapTop);
        }

        void PrepBitmap(SKCanvas bitmapCanvas, int bitmapSize)
        {
            float radius = bitmapSize / 2f;
   //         bitmapCanvas.ClipPath(new SKPath());

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.White;

                bitmapCanvas.DrawCircle(radius, radius, radius, paint);
            }

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Black;
                paint.StrokeWidth = 1;

                bitmapCanvas.DrawCircle(radius, radius, radius, paint);
                bitmapCanvas.DrawLine(radius, 0, radius, bitmapSize, paint);
                bitmapCanvas.DrawLine(0, radius, bitmapSize, radius, paint);
            }

            // Set clipping path for all future drawing
            SKPath clipPath = new SKPath();
            clipPath.AddCircle(radius, radius, radius);
            bitmapCanvas.ClipPath(clipPath);
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
            PrepBitmap(bitmapCanvas, bitmapSize);
        }
    }
}