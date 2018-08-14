using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
	public partial class BitmapDissolvePage : ContentPage
	{
        SKBitmap bitmap1 = BitmapExtensions.LoadBitmapResource(
            typeof(GradientTransitionsPage),
            "SkiaSharpFormsDemos.Media.SeatedMonkey.jpg");

        SKBitmap bitmap2 = BitmapExtensions.LoadBitmapResource(
            typeof(GradientTransitionsPage),
            "SkiaSharpFormsDemos.Media.FacePalm.jpg");

        public BitmapDissolvePage ()
		{
			InitializeComponent ();
		}

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                float progress = (float)progressSlider.Value;

                paint.Color = paint.Color.WithAlpha((byte)(0xFF * (1 - progress)));
                canvas.DrawBitmap(bitmap1, info.Rect, BitmapStretch.Uniform, paint: paint);

                paint.Color = paint.Color.WithAlpha((byte)(0xFF * progress));
                canvas.DrawBitmap(bitmap2, info.Rect, BitmapStretch.Uniform, paint: paint);
            }
        }
    }
}