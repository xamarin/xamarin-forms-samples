using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
    public partial class SeparableBlendModesPage : ContentPage
    {
        SKBitmap bitmap = BitmapExtensions.LoadBitmapResource(
                            typeof(SeparableBlendModesPage),
                            "SkiaSharpFormsDemos.Media.MountainClimbers.jpg");

        public SeparableBlendModesPage()
        {
            InitializeComponent();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            canvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            canvas.DrawBitmap(bitmap, info.Rect, BitmapStretch.Uniform);

            // Get values from XAML controls
            SKBlendMode blendMode =
                (SKBlendMode)(blendModePicker.SelectedIndex == -1 ?
                                            0 : blendModePicker.SelectedItem);

            float grayShade = (float)grayShadeSlider.Value;

            using (SKPaint paint = new SKPaint())
            {
                paint.Color = SKColor.FromHsl(0, 0, 100 * grayShade);
                paint.BlendMode = blendMode;

                canvas.DrawRect(info.Rect, paint);
;            }
        }
    }
}
