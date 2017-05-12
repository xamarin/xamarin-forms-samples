using System;
using SkiaSharp;

namespace SkiaSharpFormsDemos.Curves
{
    static class PathExtensions
    {
        public static SKPath CloneWithTransform(this SKPath pathIn, Func<SKPoint, SKPoint> transform)
        {
            SKPath pathOut = new SKPath();




     



            using (SKPath.RawIterator iterator = pathIn.CreateRawIterator())
            {
                SKPoint[] points = new SKPoint[4];
                SKPathVerb pathVerb = SKPathVerb.Move;
                SKPoint firstPoint = new SKPoint();
                SKPoint lastPoint = new SKPoint();

                while ((pathVerb = iterator.Next(points)) != SKPathVerb.Done)
                {
                    switch (pathVerb)
                    {
                        case SKPathVerb.Move:
                            pathOut.MoveTo(transform(points[0]));
                            firstPoint = lastPoint = points[0];
                            break;

                        case SKPathVerb.Line:
                            // Interpolate(pathOut, transform, points[0], points[1]);
                            // pathOut.LineTo(transform(points[1]));


                            SKPoint[] linePoints = Interpolate(points[0], points[1]);

                            foreach (SKPoint pt in linePoints)
                            {
                                pathOut.LineTo(transform(pt));
                            }

                            lastPoint = points[1];
                            break;

                        case SKPathVerb.Cubic:
                            System.Diagnostics.Debug.WriteLine("Cubic");

                            pathOut.CubicTo(transform(points[1]), 
                                            transform(points[2]),
                                            transform(points[3]));
                            lastPoint = points[3];
                            break;

                        case SKPathVerb.Quad:
                            System.Diagnostics.Debug.WriteLine("Quadratic");

                            SKPoint[] quadPoints = FlattenQuadraticBezier(points[0], points[1], points[2]);

                            foreach (SKPoint pt in quadPoints)
                            {
                                pathOut.LineTo(transform(pt));
                            }

                      //      pathOut.QuadTo(transform(points[1]),
                        //                   transform(points[2]));
                            lastPoint = points[2];
                            break;

                        case SKPathVerb.Conic:
                            System.Diagnostics.Debug.WriteLine("Conic");


                            pathOut.ConicTo(transform(points[1]),
                                            transform(points[2]), iterator.ConicWeight());
                            lastPoint = points[2];
                            break;

                        case SKPathVerb.Close:
                            Interpolate(lastPoint, firstPoint);
                            firstPoint = lastPoint = new SKPoint(0, 0);

                            pathOut.Close();
                            break;
                    }
                }
            }
            return pathOut;
        }
/*
        static void Interpolate(SKPath pathOut, Func<SKPoint, SKPoint> transform, SKPoint pt0, SKPoint pt1)
        {
            int count = (int)Math.Sqrt(Math.Pow(pt1.X - pt0.X, 2) + Math.Pow(pt1.Y - pt0.Y, 2));

            for (int i = 1; i < count; i++)
            {
                SKPoint pt = transform(new SKPoint(((count - i) * pt0.X + i * pt1.X) / count,
                                                   ((count - i) * pt0.Y + i * pt1.Y) / count));
                pathOut.LineTo(pt);
            }
        }
*/

        static SKPoint[] Interpolate(SKPoint pt0, SKPoint pt1)
        {
            int count = (int)Math.Max(1, Length(pt0, pt1));
            SKPoint[] points = new SKPoint[count];

            for (int i = 0; i < count; i++)
            {
                float t = (i + 1f) / count;
                float x = (1 - t) * pt0.X + t * pt1.X;
                float y = (1 - t) * pt0.Y + t * pt1.Y;
                points[i] = new SKPoint(x, y);
            }

            return points;
        }




        public static SKPoint[] FlattenQuadraticBezier(SKPoint pt0, SKPoint pt1, SKPoint pt2)
        {
            int count = (int)Math.Max(1, Length(pt0, pt1) + Length(pt1, pt2));
            SKPoint[] points = new SKPoint[count];

            for (int i = 0; i < count; i++)
            {
                float t = (i + 1f) / count;
                float x = (1 - t) * (1 - t) * pt0.X + 2 * t * (1 - t) * pt1.X + t * t * pt2.X;
                float y = (1 - t) * (1 - t) * pt0.Y + 2 * t * (1 - t) * pt1.Y + t * t * pt2.Y;
                points[i] = new SKPoint(x, y);
            }

            return points;
        }


        public static SKPoint[] FlattenCubicBezier(SKPoint pt0, SKPoint pt1, SKPoint pt2, SKPoint pt3)
        {
            int count = (int)Math.Max(1, Length(pt0, pt1) + Length(pt1, pt2) + Length(pt2, pt3));
            SKPoint[] points = new SKPoint[count];

            for (int i = 0; i < count; i++)
            {
                float t = (i + 1f) / count;
                float x = (1 - t) * (1 - t) * (1 - t) * pt0.X +
                          3 * t * (1 - t) * (1 - t) * pt1.X +
                          3 * t * t * (1 - t) * pt2.X +
                          t * t * t * pt3.X;
                float y = (1 - t) * (1 - t) * (1 - t) * pt0.Y +
                          3 * t * (1 - t) * (1 - t) * pt1.Y +
                          3 * t * t * (1 - t) * pt2.Y +
                          t * t * t * pt3.Y;
                points[i] = new SKPoint(x, y);
            }

            return points;
        }

        public static SKPoint[] FlattenRationalQuadraticBezier(SKPoint pt0, SKPoint pt1, SKPoint pt2, float weight)
        {
            int count = (int)Math.Max(1, Length(pt0, pt1) + Length(pt1, pt2));
            SKPoint[] points = new SKPoint[count];

            for (int i = 0; i < count; i++)
            {
                float t = (i + 1f) / count;

                float d = (1 - t) * (1 - t) + 2 * weight * t * (1 - t) + t * t;

                float x = ((1 - t) * (1 - t) * pt0.X + 2 * weight * t * (1 - t) * pt1.X + t * t * pt2.X) / d;
                float y = ((1 - t) * (1 - t) * pt0.Y + 2 * weight * t * (1 - t) * pt1.Y + t * t * pt2.Y) / d;
                points[i] = new SKPoint(x, y);
            }

            return points;
        }


        static double Length(SKPoint pt0, SKPoint pt1)
        {
            return Math.Sqrt(Math.Pow(pt1.X - pt0.X, 2) + Math.Pow(pt1.Y - pt0.Y, 2));
        }
    }
}
