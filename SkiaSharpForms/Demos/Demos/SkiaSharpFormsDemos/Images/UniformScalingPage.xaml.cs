using System;
using System.IO;
using System.Reflection;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Images
{
	public partial class UniformScalingPage : ContentPage
	{
        SKBitmap bitmap = 
            BitmapExtensions.LoadBitmapResource(typeof(UniformScalingPage), 
                                                "SkiaSharpFormsDemos.Media.Banana.jpg");

		public UniformScalingPage ()
		{
			InitializeComponent ();



/*
            string resourceID = "SkiaSharpFormsDemos.Media.Banana.jpg";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            using (SKManagedStream skStream = new SKManagedStream(stream))
            {
                bitmap = SKBitmap.Decode(skStream);
            }
*/
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float scale = Math.Min((float)info.Width / bitmap.Width, (float)info.Height / bitmap.Height);
            float x = (info.Width - scale * bitmap.Width) / 2;
            float y = (info.Height - scale * bitmap.Height) / 2;
            SKRect destRect = new SKRect(x, y, x + scale * bitmap.Width, y + scale * bitmap.Height);

            canvas.DrawBitmap(bitmap, destRect);
        }
    }
}