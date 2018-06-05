using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;













using System.IO;










namespace SkiaSharpFormsDemos.Images
{
    public partial class HelloBitmapPage : ContentPage
    {
        const string TEXT = "Hello, Bitmap!";
        SKBitmap helloBitmap;

        public HelloBitmapPage()
        {
            InitializeComponent();

            using (SKPaint textPaint = new SKPaint { TextSize = 24 })
            {
                SKRect bounds = new SKRect();
                textPaint.MeasureText(TEXT, ref bounds);

                System.Diagnostics.Debug.WriteLine(bounds);

                helloBitmap = new SKBitmap((int)bounds.Right, 
                                           (int)bounds.Height);

                using (SKCanvas bitmapCanvas = new SKCanvas(helloBitmap))
                {
                    bitmapCanvas.Clear();
                    bitmapCanvas.DrawText(TEXT, 0, -bounds.Top, textPaint);
                }
            }

            return;

            // iOS: Requires NSPhotoLibraryUsageDescription in Info.plist
            // Android: Requires android.permission.WRITE_EXTERNAL_STORAGE in AndroidManifest.xml
            // UWP: Requires Pictures Library capability in Package.appxmanifest

            SKImage image = SKImage.FromBitmap(helloBitmap);
            SKData data = image.Encode();
            string picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string filename = "whatsit.png";
            File.WriteAllBytes(Path.Combine(picturesPath, filename), data.ToArray());

           


        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            for (float y = 0; y < info.Height; y += helloBitmap.Height)
                for (float x = 0; x < info.Width; x += helloBitmap.Width)
                {
                    canvas.DrawBitmap(helloBitmap, x, y);
                }
        }
    }
}