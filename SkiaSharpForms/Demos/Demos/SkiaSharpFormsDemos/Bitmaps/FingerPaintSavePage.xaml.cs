using System;
using System.Collections.Generic;

using Xamarin.Forms;

using TouchTracking;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
    public partial class FingerPaintSavePage : ContentPage
    {
        Dictionary<long, SKPath> inProgressPaths = new Dictionary<long, SKPath>();
        List<SKPath> completedPaths = new List<SKPath>();

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };

        SKBitmap bitmap = null;
        SKCanvas bitmapCanvas = null;

        public FingerPaintSavePage ()
        {
            InitializeComponent ();
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = new SKPath();
                        path.MoveTo(ConvertToPixel(args.Location));
                        inProgressPaths.Add(args.Id, path);
                        //      canvasView.InvalidateSurface();
                        UpdateBitmap();
                    }
                    break;

                case TouchActionType.Moved:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = inProgressPaths[args.Id];
                        path.LineTo(ConvertToPixel(args.Location));
    //                    canvasView.InvalidateSurface();
                        UpdateBitmap();
                    }
                    break;

                case TouchActionType.Released:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        completedPaths.Add(inProgressPaths[args.Id]);
                        inProgressPaths.Remove(args.Id);
  //                      canvasView.InvalidateSurface();
                        UpdateBitmap();
                    }
                    break;

                case TouchActionType.Cancelled:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        inProgressPaths.Remove(args.Id);
//                        canvasView.InvalidateSurface();
                        UpdateBitmap();
                    }
                    break;
            }
        }

        void UpdateBitmap()
        {
            bitmapCanvas.Clear();

            foreach (SKPath path in completedPaths)
            {
                bitmapCanvas.DrawPath(path, paint);
            }

            foreach (SKPath path in inProgressPaths.Values)
            {
                bitmapCanvas.DrawPath(path, paint);
            }

            canvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            if (bitmap == null)
            {
                bitmap = new SKBitmap(info.Width, info.Height);
            }
            else if (bitmap.Width < info.Width || bitmap.Height < info.Height)
            {
                SKBitmap newBitmap = new SKBitmap(Math.Max(bitmap.Width, info.Width),
                                                  Math.Max(bitmap.Height, info.Height));

                using (SKCanvas newCanvas = new SKCanvas(newBitmap))
                {
                    newCanvas.Clear();
                    newCanvas.DrawBitmap(bitmap, 0, 0);
                }

                bitmap = newBitmap;
            }

            canvas.Clear();
            canvas.DrawBitmap(bitmap, 0, 0);
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
            bitmapCanvas.Clear();
            canvasView.InvalidateSurface();
        }

        async void OnSaveButtonClicked(object sender, EventArgs args)
        {
            SKData data = SKImage.FromBitmap(bitmap).Encode();
            DateTime dt = DateTime.Now;
            string filename = String.Format("FingerPaint-{0:D4}{1:D2}{2:D2}-{3:D2}{4:D2}{5:D2}{6:D3}.png",
                                            dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);

            IPhotoLibrary photoLibrary = DependencyService.Get<IPhotoLibrary>();
            bool result = await photoLibrary.SavePhotoAsync(data.ToArray(), "FingerPaint", filename);

            if (!result)
            {
                await DisplayAlert("FingerPaint", "Artwork could not be saved. Sorry!", "OK");
            }
        }
    }
}