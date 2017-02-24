using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Curves
{
    public partial class CornerArcPage : InteractivePage
    {
        public CornerArcPage()
        {
            touchPoints = new TouchPoint[3];

            for (int i = 0; i < 3; i++)
            {
                TouchPoint touchPoint = new TouchPoint
                {
                    Center = new SKPoint(i == 0 ? 100 : 500,
                                         i != 2 ? 100 : 500)
                };
                touchPoints[i] = touchPoint;
            }

            InitializeComponent();

            baseCanvasView = canvasView;
            radiusSlider.Value = 200;
        }

        void sliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (canvasView != null)
            {
                canvasView.InvalidateSurface();
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPath path = new SKPath())
            {
                path.MoveTo(touchPoints[0].Center);

                float radius = (float)radiusSlider.Value;

                path.ArcTo(touchPoints[1].Center, 
                           touchPoints[2].Center, 
                           radius);

                canvas.DrawPath(path, strokePaint);

                // Draw the circle the arc wraps around
                SKPoint v1 = new SKPoint(touchPoints[0].Center.X - touchPoints[1].Center.X,
                                         touchPoints[0].Center.Y - touchPoints[1].Center.Y);
                SKPoint v2 = new SKPoint(touchPoints[2].Center.X - touchPoints[1].Center.X,
                                         touchPoints[2].Center.Y - touchPoints[1].Center.Y);

                double dotProduct = v1.X * v2.X + v1.Y * v2.Y;
                double angleBetween = Math.Acos(dotProduct /
                                (Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y) *
                                 Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y)));


                double acos = Math.Acos(dotProduct);
                double v1Mag = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y);
                double v2Mag = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y);


                float hypotenuse = radius / (float)Math.Sin(angleBetween / 2);

                SKPoint vMid = new SKPoint((v1.X + v2.X) / 2, (v1.Y + v2.Y) / 2);
                float vMidMag = (float)Magnitude(vMid);
                vMid = new SKPoint(vMid.X / vMidMag, vMid.Y / vMidMag);
                SKPoint center = new SKPoint(touchPoints[1].Center.X + vMid.X * hypotenuse,
                                             touchPoints[1].Center.Y + vMid.Y * hypotenuse);



                // Draw red line from arc path to touchPoints[2]
                SKPoint lastPoint = path.LastPoint;
                path.Reset();
                path.MoveTo(lastPoint);
                path.LineTo(touchPoints[2].Center);
                canvas.DrawPath(path, redStrokePaint);




                // TODO: Draw circle
            }

            foreach (TouchPoint touchPoint in touchPoints)
            {
                touchPoint.Paint(canvas);
            }
        }

        double Magnitude(SKPoint v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

    }
}
