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


                System.Diagnostics.Debug.WriteLine(path.ToSvgPathData());


                // Draw the circle that the arc wraps around
                SKPoint v1 = Normalize(touchPoints[0].Center - touchPoints[1].Center); // MakeVector(touchPoints[1].Center, touchPoints[0].Center));
                SKPoint v2 = Normalize(touchPoints[2].Center - touchPoints[1].Center); //  MakeVector(touchPoints[1].Center, touchPoints[2].Center));

                double dotProduct = v1.X * v2.X + v1.Y * v2.Y;
                double angleBetween = Math.Acos(dotProduct);
                float hypotenuse = radius / (float)Math.Sin(angleBetween / 2);
                SKPoint vMid = Normalize(new SKPoint((v1.X + v2.X) / 2, (v1.Y + v2.Y) / 2));
                SKPoint center = new SKPoint(touchPoints[1].Center.X + vMid.X * hypotenuse,
                                             touchPoints[1].Center.Y + vMid.Y * hypotenuse);





                // Draw red line from arc path to touchPoints[2]
                SKPoint lastPoint = path.LastPoint;
                path.Reset();
                path.MoveTo(lastPoint);
                path.LineTo(touchPoints[2].Center);
                canvas.DrawPath(path, redStrokePaint);


                canvas.DrawCircle(center.X, center.Y, radius, redStrokePaint);

                // TODO: Draw circle
            }

            foreach (TouchPoint touchPoint in touchPoints)
            {
                touchPoint.Paint(canvas);
            }
        }

        //SKPoint MakeVector(SKPoint ptFrom, SKPoint ptTo)
        //{
        //    return new SKPoint(ptTo.X - ptFrom.X, ptTo.Y - ptFrom.Y);
        //}

        SKPoint Normalize(SKPoint v)
        {
            float magnitude = Magnitude(v);
            return new SKPoint(v.X / magnitude, v.Y / magnitude);
        }

        float Magnitude(SKPoint v)
        {
            return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

    }
}
