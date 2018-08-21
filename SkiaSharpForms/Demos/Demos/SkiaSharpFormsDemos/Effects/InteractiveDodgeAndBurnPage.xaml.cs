using System;
using System.Collections.Generic;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using TouchTracking;

namespace SkiaSharpFormsDemos.Effects
{
	public partial class InteractiveDodgeAndBurnPage : ContentPage
	{
        SKBitmap bitmap = BitmapExtensions.LoadBitmapResource(
            typeof(InteractiveDodgeAndBurnPage),
            "SkiaSharpFormsDemos.Media.SeatedMonkey.jpg");

        SKBitmap dodgeMaskBitmap;
        SKBitmap burnMaskBitmap;
        SKRect bitmapRect;


        Dictionary<long, SKPath> inProgressPaths = new Dictionary<long, SKPath>();
        List<SKPath> completedPaths = new List<SKPath>();


        Dictionary<long, SKPoint> touchPoints = new Dictionary<long, SKPoint>();

        public InteractiveDodgeAndBurnPage ()
		{
			InitializeComponent ();

            dodgeMaskBitmap = new SKBitmap(bitmap.Width, bitmap.Height);
            using (SKCanvas canvas = new SKCanvas(dodgeMaskBitmap))
            {
                canvas.Clear(SKColors.Black);
            }

            burnMaskBitmap = new SKBitmap(bitmap.Width, bitmap.Height);
            using (SKCanvas canvas = new SKCanvas(burnMaskBitmap))
            {
                canvas.Clear(SKColors.White);
            }
		}

        void OnModeSwitchToggled(object sender, ToggledEventArgs args)
        {

        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Find largest size rectangle in canvas
            float scale = Math.Min((float)info.Width / bitmap.Width,
                                   (float)info.Height / bitmap.Height);
            bitmapRect = SKRect.Create(scale * bitmap.Width, scale * bitmap.Height);
            float x = (info.Width - bitmapRect.Width) / 2;
            float y = (info.Height - bitmapRect.Height) / 2;
            bitmapRect.Offset(x, y);

            canvas.DrawBitmap(bitmap, bitmapRect);

            using (SKPaint paint = new SKPaint())
            {
                paint.BlendMode = SKBlendMode.ColorDodge;
                canvas.DrawBitmap(dodgeMaskBitmap, bitmapRect, paint);

                paint.BlendMode = SKBlendMode.ColorBurn;
                canvas.DrawBitmap(burnMaskBitmap, bitmapRect, paint);
            }
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            if (args.Type == TouchActionType.Pressed)
            { 
                SKPoint center = ConvertToBitmapPixel(args.Location);
                const float radius = 100;

                using (SKPaint paint = new SKPaint())
                {
                    if (!modeSwitch.IsToggled)
                    {
                        // Dodge: Add white to black bitmap
                        using (SKCanvas canvas = new SKCanvas(dodgeMaskBitmap))
                        {
                            //     paint.Color = new SKColor(0xFF, 0xFF, 0xFF, 0x10);

                            paint.Shader = SKShader.CreateRadialGradient(
                                                center,
                                                radius,
                                                new SKColor[] 
                                                {
                                                    new SKColor(0xFF, 0xFF, 0xFF, 0x10),
                                                    new SKColor(0xFF, 0xFF, 0xFF, 0)
                                                },
                                                null,
                                                SKShaderTileMode.Clamp);

                            paint.BlendMode = SKBlendMode.Plus;
                            canvas.DrawCircle(center, radius, paint);
                        }
                    }
                    else
                    {
                        // Burn: Add black to white bitmap
                        using (SKCanvas canvas = new SKCanvas(burnMaskBitmap))
                        {
                            paint.Shader = SKShader.CreateRadialGradient(
                                                center,
                                                radius,
                                                new SKColor[]
                                                {
                                                    new SKColor(0, 0, 0, 0x10),
                                                    new SKColor(0, 0, 0, 0)
                                                },
                                                null,
                                                SKShaderTileMode.Clamp);

                            canvas.DrawCircle(center, radius, paint);
                        }
                    }
                }

                canvasView.InvalidateSurface();



                /*
                            switch (args.Type)
                            {
                                case TouchActionType.Pressed:
                                    if (!touchPoints.ContainsKey(args.Id))
                                    {
                             //           touchPoints.Add(args.Id, point);
                                    }
                                    return;

                                    if (!inProgressPaths.ContainsKey(args.Id))
                                    {
                                        SKPath path = new SKPath();
                                        path.MoveTo(ConvertToBitmapPixel(args.Location));
                                        inProgressPaths.Add(args.Id, path);
                                        UpdateBitmap();
                                    }
                                    break;
                                case TouchActionType.Moved:
                                    if (touchPoints.ContainsKey(args.Id))
                                    {
                                        DrawLine(touchPoints[args.Id], point);
                                        touchPoints[args.Id] = point;
                                    }
                                    return;


                                    if (inProgressPaths.ContainsKey(args.Id))
                                    {
                                        SKPath path = inProgressPaths[args.Id];
                                        path.LineTo(ConvertToBitmapPixel(args.Location));
                                        UpdateBitmap();
                                    }
                                    break;

                                case TouchActionType.Released:
                                    if (touchPoints.ContainsKey(args.Id))
                                    {
                                        DrawLine(touchPoints[args.Id], point);
                                        touchPoints.Remove(args.Id);
                                    }
                                    return;


                                    if (inProgressPaths.ContainsKey(args.Id))
                                    {
                                        completedPaths.Add(inProgressPaths[args.Id]);
                                        inProgressPaths.Remove(args.Id);
                                        UpdateBitmap();
                                    }
                                    break;

                                case TouchActionType.Cancelled:
                                    if (touchPoints.ContainsKey(args.Id))
                                    {
                                        touchPoints.Remove(args.Id);
                                    }
                                    return;


                                    if (inProgressPaths.ContainsKey(args.Id))
                                    {
                                        inProgressPaths.Remove(args.Id);
                                        UpdateBitmap();
                                    }
                                    break;
                */
            }
        }

        SKPoint ConvertToBitmapPixel(Point pt)
        {
            SKPoint ptPixel = new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                                          (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));

            SKPoint ptRect = ptPixel - new SKPoint(bitmapRect.Left, bitmapRect.Top);

            SKPoint ptBitmap = new SKPoint(ptRect.X * bitmap.Width / bitmapRect.Width,
                                           ptRect.Y * bitmap.Height / bitmapRect.Height);

            return ptBitmap;

            System.Diagnostics.Debug.WriteLine("{0} --> {1}", pt, ptPixel);

            return ptPixel - new SKPoint(bitmapRect.Left, bitmapRect.Top);
        }
/*
        void DrawLine(SKPoint pt1, SKPoint pt2)
        {
            if (!modeSwitch.IsToggled)
            {
                // Dodge: Add white to black bitmap
                using (SKCanvas canvas = new SKCanvas(dodgeMaskBitmap))
                {
                    paint.Color = new SKColor(0xFF, 0xFF, 0xFF, 0x10);
                    paint.BlendMode = SKBlendMode.Plus;
                    canvas.DrawLine(pt1, pt2, paint);
                }
            }
            else
            {
                // Burn: Add black to white bitmap



            }

            canvasView.InvalidateSurface();
        }
*/
        void UpdateBitmap()
        {



/*
            using (SKCanvas saveBitmapCanvas = new SKCanvas(saveBitmap))
            {
                saveBitmapCanvas.Clear();

                foreach (SKPath path in completedPaths)
                {
                    saveBitmapCanvas.DrawPath(path, paint);
                }

                foreach (SKPath path in inProgressPaths.Values)
                {
                    saveBitmapCanvas.DrawPath(path, paint);
                }
            }
*/
            canvasView.InvalidateSurface();
        }
    }
}