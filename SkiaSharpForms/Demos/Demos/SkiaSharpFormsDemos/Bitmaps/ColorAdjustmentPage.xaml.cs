using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
    public partial class ColorAdjustmentPage : ContentPage
	{
        SKBitmap originalBitmap =
            BitmapExtensions.LoadBitmapResource(typeof(FillRectanglePage),
                                                "SkiaSharpFormsDemos.Media.Banana.jpg");
        SKBitmap adjustedBitmap;

        public ColorAdjustmentPage ()
		{
            InitializeComponent();

            adjustedBitmap = new SKBitmap(originalBitmap.Width, originalBitmap.Height);
            OnSliderValueChanged(null, null);
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            float hueAdjust = (float)hueSlider.Value;
            hueLabel.Text = $"Hue Adjustment: {hueAdjust:F0}";

            float saturationAdjust = (float)Math.Pow(2, saturationSlider.Value);
            saturationLabel.Text = $"Saturation Adjustment: {saturationAdjust:F2}";

            float luminosityAdjust = (float)Math.Pow(2, luminositySlider.Value);
            luminosityLabel.Text = $"Luminosity Adjustment: {luminosityAdjust:F2}";

            TransferPixels(hueAdjust, saturationAdjust, luminosityAdjust);
            canvasView.InvalidateSurface();
        }

        void TransferPixels(float hueAdjust, float saturationAdjust, float luminosityAdjust)
        {
            SKColor[] originalPixels = originalBitmap.Pixels;
            SKColor[] adjustedPixels = new SKColor[originalPixels.Length];

            for (int i = 0; i < originalPixels.Length; i++)
            {
                SKColor originalColor = originalPixels[i];

                originalColor.ToHsl(out float hue, out float saturation, out float luminosity);
                hue = (hue + hueAdjust) % 360;
                saturation = Math.Max(0, Math.Min(100, saturationAdjust * saturation));
                luminosity = Math.Max(0, Math.Min(100, luminosityAdjust * luminosity));

                adjustedPixels[i] = SKColor.FromHsl(hue, saturation, luminosity);
            }

            adjustedBitmap.Pixels = adjustedPixels;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            canvas.DrawBitmap(adjustedBitmap, info.Rect, BitmapStretch.Uniform);
        }
    }
}