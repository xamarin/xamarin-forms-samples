using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using TouchTracking;

namespace SkiaSharpFormsDemos.Effects
{
	public partial class ImageMagnificationPage : ContentPage
	{
        static SKBitmap bitmap;

        HttpClient httpClient = new HttpClient();
        List<long> touchPoints = new List<long>();
        SKRect bitmapRect;

        // For the magnification
        bool showMagnification;
        SKRect subsetRect;
        SKPoint displayPoint;

        public ImageMagnificationPage ()
		{
			InitializeComponent ();

            bitmap = BitmapExtensions.LoadBitmapResource(typeof(ImageMagnificationPage), "SkiaSharpFormsDemos.Media.SeatedMonkey.jpg");
		}

        async protected override void OnAppearing()
        {
            base.OnAppearing();



            return;



            if (bitmap != null)
                return;

            // Load bitmap
            string url = "https://upload.wikimedia.org/wikipedia/commons/1/1e/Pieter_Bruegel_the_Elder_-_Children%E2%80%99s_Games_-_Google_Art_Project.jpg";
            activityIndicator.IsRunning = true;

            try
            {
                using (Stream stream = await httpClient.GetStreamAsync(url))
                using (MemoryStream memStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);
                    bitmap = SKBitmap.Decode(memStream);
                    canvasView.InvalidateSurface();
                }
            }
            catch (Exception exc)
            {
                errorLabel.Text = "Could not load bitmap: " + exc.Message;
            }
            activityIndicator.IsRunning = false;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            if (bitmap == null)
                return;

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Find rectangle for display
            float scale = Math.Min((float)info.Width / bitmap.Width,
                                   (float)info.Height / bitmap.Height);
            bitmapRect = SKRect.Create(scale * bitmap.Width, scale * bitmap.Height);
            float x = (info.Width - bitmapRect.Width) / 2;
            float y = (info.Height - bitmapRect.Height) / 2;
            bitmapRect.Offset(x, y);

            canvas.DrawBitmap(bitmap, bitmapRect);

            if (showMagnification)
            {
                using (SKPaint paint = new SKPaint())
                {
                    paint.ImageFilter = SKImageFilter.CreateMagnifier(new SKRect(100, 50, 175, 140), 0.1f);
                    canvas.DrawBitmap(bitmap, /* new SKRect(0, 0, 200, 200) */ new SKPoint(), paint);
                }
            }
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!touchPoints.Contains(args.Id))
                    {
                        touchPoints.Add(args.Id);
                        ShowEnlargedImage(true, args.Location);
                    }
                    break;

                case TouchActionType.Moved:
                    if (touchPoints.Contains(args.Id))
                    {
                        ShowEnlargedImage(true, args.Location);
                    }
                    break;

                case TouchActionType.Released:
                case TouchActionType.Cancelled:
                    if (touchPoints.Contains(args.Id))
                    {
                        ShowEnlargedImage(false, args.Location);
                        touchPoints.Remove(args.Id);
                    }
                    break;
            }
        }

        void ShowEnlargedImage(bool show, Point pt)
        {
            if (!show)
            {
                showMagnification = false;
                canvasView.InvalidateSurface();
                return;
            }

            SKPoint pixelPoint = new SKPoint(
                (float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));

            // pixelPoint -= ....

            SKPoint offsetPoint = 
                pixelPoint - new SKPoint(bitmapRect.Left, bitmapRect.Top);

            SKPoint bitmapPoint =
                new SKPoint(bitmap.Width * offsetPoint.X / bitmapRect.Width,
                            bitmap.Height * offsetPoint.Y / bitmapRect.Height);


            showMagnification = true;
            SKPoint upperLeftPt = new SKPoint(bitmapPoint.X - 200, bitmapPoint.Y - 200);

            subsetRect = new SKRect(bitmapPoint.X - 200,
                                    bitmapPoint.Y - 200,
                                    bitmapPoint.X + 200,
                                    bitmapPoint.Y + 200);

            displayPoint =
                new SKPoint(bitmapRect.Width * upperLeftPt.X / bitmap.Width,
                            bitmapRect.Height * upperLeftPt.Y / bitmap.Width);

            displayPoint += new SKPoint(bitmapRect.Left, bitmapRect.Top);

            canvasView.InvalidateSurface();

        }
    }
}