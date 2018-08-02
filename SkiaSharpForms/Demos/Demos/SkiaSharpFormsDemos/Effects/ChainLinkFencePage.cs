using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
	public class ChainLinkFencePage : ContentPage
	{
        const int SIZE = 160; // 64;
        const int THICKNESS = 10; // 8;
        static readonly float CORNER = THICKNESS / (float)Math.Sqrt(2);

        SKBitmap tileBitmap = new SKBitmap(SIZE, SIZE);

        SKBitmap monkeyBitmap = BitmapExtensions.LoadBitmapResource(
            typeof(ChainLinkFencePage), "SkiaSharpFormsDemos.Media.SeatedMonkey.jpg");

        // ChainLinkFence chainLinkFence = new ChainLinkFence(160);     // Bitmap read-only property

		public ChainLinkFencePage ()
		{
            using (SKCanvas canvas = new SKCanvas(tileBitmap))
            using (SKPaint paint = new SKPaint())
            using (SKPath path = new SKPath())
            {
                

                canvas.Clear();

                paint.IsAntialias = true;

                // Upper-Left
                LinkQuadrant(canvas, path, paint, new SKRect(0, 0, SIZE / 2, SIZE / 2));

                // Lower-right
                LinkQuadrant(canvas, path, paint, new SKRect(SIZE / 2, SIZE / 2, SIZE, SIZE));

                paint.Shader = null;
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = THICKNESS;

                // Upper-right
                EmptyQuadrant(canvas, paint, new SKRect(SIZE / 2, 0, SIZE, SIZE / 2));

                // Lower-left
                EmptyQuadrant(canvas, paint, new SKRect(0, SIZE / 2, SIZE / 2, SIZE));


            }





            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
		}

        void LinkQuadrant(SKCanvas canvas, SKPath path, SKPaint paint, SKRect rect)
        {
            SKPoint center = new SKPoint(rect.MidX, rect.MidY);

            SKShader straightShader = SKShader.CreateLinearGradient(new SKPoint(rect.Right, rect.Top),
                                                                    new SKPoint(rect.Left, rect.Bottom),
                                                                    new SKColor[] { SKColors.Silver, SKColors.Black },
                                                                    new float[] { 0.4f, 0.6f }, SKShaderTileMode.Clamp);


            Straight(path, center, new SKPoint(rect.Left, rect.Top), new SKPoint(rect.Left, rect.Top + CORNER), new SKPoint(rect.Left + CORNER, rect.Top));
       //     paint.Color = SKColors.Silver;
            paint.Shader = straightShader;
            canvas.DrawPath(path, paint);

            Straight(path, center, new SKPoint(rect.Right, rect.Bottom), new SKPoint(rect.Right, rect.Bottom - CORNER), new SKPoint(rect.Right - CORNER, rect.Bottom));
      //      paint.Color = SKColors.Red;
       //     paint.Shader = straightShader;
            canvas.DrawPath(path, paint);

            Curved(path, center, new SKPoint(rect.Right, rect.Top), new SKPoint(rect.Right, rect.Top + CORNER), new SKPoint(rect.Right - CORNER, rect.Top));
            paint.Color = SKColors.Green;

            paint.Shader = SKShader.CreateLinearGradient(new SKPoint(rect.Right, rect.Top),
                                                                    new SKPoint(rect.Left, rect.Bottom),
                                                                    new SKColor[] { SKColors.Silver, SKColors.Black },
                                                                    null, SKShaderTileMode.Clamp);


            canvas.DrawPath(path, paint);

            Curved(path, center, new SKPoint(rect.Left, rect.Bottom), new SKPoint(rect.Left, rect.Bottom - CORNER), new SKPoint(rect.Left + CORNER, rect.Bottom));
            paint.Color = SKColors.Pink;


            paint.Shader = SKShader.CreateLinearGradient(new SKPoint(rect.Right, rect.Top),
                                                                    new SKPoint(rect.Left, rect.Bottom),
                                                                    new SKColor[] { SKColors.White, SKColors.Silver },
                                                                    null, SKShaderTileMode.Clamp);

            canvas.DrawPath(path, paint);
        }

        void EmptyQuadrant(SKCanvas canvas, SKPaint paint, SKRect rect)
        {
            

            using (new SKAutoCanvasRestore(canvas))
            {
                canvas.ClipRect(rect, SKClipOperation.Intersect);

                paint.Shader = null;
                paint.Color = SKColors.Silver;

                // Upper-left
                canvas.DrawLine(rect.Left - SIZE, rect.Top + SIZE, rect.Left + SIZE, rect.Top - SIZE, paint);

                // Lower-right
                canvas.DrawLine(rect.Right - SIZE, rect.Bottom + SIZE, rect.Right + SIZE, rect.Bottom - SIZE, paint);

                // Lower-left

                paint.Shader = SKShader.CreateLinearGradient(new SKPoint(rect.MidX, rect.MidY), new SKPoint(rect.Left - rect.Width / 2, rect.Bottom + rect.Height / 2),

                                                      new SKColor[] { SKColors.Silver, SKColors.Black },
                                                                    new float[] { 0.4f, 0.6f }, SKShaderTileMode.Clamp);

                canvas.DrawLine(rect.Left - SIZE, rect.Bottom - SIZE, rect.Left + SIZE, rect.Bottom + SIZE, paint);


                // Upper-right
                paint.Shader = SKShader.CreateLinearGradient(new SKPoint(rect.Right + rect.Width / 2, rect.Top - rect.Height / 2), new SKPoint(rect.MidX, rect.MidY),

                                                      new SKColor[] { SKColors.Silver, SKColors.Black },
                                                                    new float[] { 0.4f, 0.6f }, SKShaderTileMode.Clamp);

                canvas.DrawLine(rect.Right - SIZE, rect.Top - SIZE, rect.Right + SIZE, rect.Top + SIZE, paint);
            }

        }

        void Straight(SKPath path, SKPoint center, SKPoint corner, SKPoint pt1, SKPoint pt2)
        {
            path.Reset();

            SKPoint vector = center - pt1;
      //      float length = Length(vector);
       //     Normalize(ref vector);
       //     vector.X *= (length - THICKNESS);
       //     vector.Y *= (length - THICKNESS);

            path.MoveTo(pt1);
            path.LineTo(pt1 + vector);  
            path.LineTo(pt2 + vector);
            path.LineTo(pt2);
            path.LineTo(corner);
            path.Close();
        }

        void Curved(SKPath path, SKPoint center, SKPoint corner, SKPoint pt1, SKPoint pt2)
        {
            path.Reset();

            SKPoint vector = center - pt1;

            SKPoint vector2 = vector;
            float length = Length(vector2);
            Normalize(ref vector2);
            vector2.X *= (length + THICKNESS);
            vector2.Y *= (length + THICKNESS);

            path.MoveTo(pt2);
            path.LineTo(pt2 + vector);
            path.ArcTo(new SKPoint(THICKNESS, THICKNESS), 0, SKPathArcSize.Small, SKPathDirection.CounterClockwise, pt1 + vector2);
    //        path.LineTo(pt2 + vector);
            path.LineTo(pt1);
            path.LineTo(corner);
            path.Close();
        }


        float Length(SKPoint vector)
        {
            return (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }

        void Normalize(ref SKPoint vector)
        {
            float length = Length(vector);
            vector.X /= length;
            vector.Y /= length;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            canvas.DrawBitmap(monkeyBitmap, info.Rect, BitmapStretch.UniformToFill, BitmapAlignment.Center, BitmapAlignment.Start);

            using (SKPaint paint = new SKPaint())
            {
                paint.Shader = SKShader.CreateBitmap(tileBitmap, 
                                                     SKShaderTileMode.Repeat,
                                                     SKShaderTileMode.Repeat);
                canvas.DrawRect(info.Rect, paint);
            }
        }
    }
}