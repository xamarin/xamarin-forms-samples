using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
    public partial class PorterDuffBlendModesPage : ContentPage
    {
 //       const int BitmapSize = 300;
 //       const int TextSize = 400;

        SKBitmap dstBitmap;
        SKBitmap srcBitmap;

        public PorterDuffBlendModesPage()
        {
            InitializeComponent();

            using (SKPaint paint = new SKPaint())
            {
                // Create source bitmap with cyan text
                paint.TextSize = 400;
                paint.Color = SKColors.Cyan;

                SKRect bounds = new SKRect();
                paint.MeasureText("P-D", ref bounds);

                srcBitmap = new SKBitmap((int)bounds.Width, (int)bounds.Height);

                using (SKCanvas canvas = new SKCanvas(srcBitmap))
                {
                    canvas.Clear();
                    canvas.DrawText("P-D", -bounds.Left, -bounds.Top, paint);
                }

                // Create destination bitmap 
                dstBitmap = new SKBitmap(srcBitmap.Width, srcBitmap.Height);

                // Make the yellow rectangle smaller than the bitmap
                SKRect rect = new SKRect(0.05f * dstBitmap.Width,
                                         0.10f * dstBitmap.Height,
                                         0.95f * dstBitmap.Width,
                                         0.90f * dstBitmap.Height);

                paint.Color = SKColors.Yellow;

                using (SKCanvas canvas = new SKCanvas(dstBitmap))
                {
                    canvas.Clear();
                    canvas.DrawRect(rect, paint);
                }
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Make square display rectangle smaller than canvas
            float size = 0.9f * Math.Min(info.Width, info.Height);
            float x = (info.Width - size) / 2;
            float y = (info.Height - size) / 2;
            SKRect rect = new SKRect(x, y, x + size, y + size);

            using (SKPaint paint = new SKPaint())
            {
                // Draw destination
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(rect.Right, rect.Top),
                                    new SKPoint(rect.Left, rect.Bottom),
                                    new SKColor[] { new SKColor(0xC0, 0x80, 0x00), // 0xFF, 0xDC, 0x01),
                                                    new SKColor(0xC0, 0x80, 0x00, 0), // 0xFF, 0xDC, 0x01, 0),
                                                    SKColors.Transparent },
                                    new float[] { 0.45f, 0.55f, 1 },
                                    SKShaderTileMode.Clamp);

                canvas.DrawRect(rect, paint);

                // Draw source
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(rect.Left, rect.Top),
                                    new SKPoint(rect.Right, rect.Bottom),
                                    new SKColor[] { new SKColor(0x00, 0x80, 0xC0), // 0x68, 0xC7, 0xE8),
                                                    new SKColor(0x00, 0x80, 0xC0, 0), // 0x68, 0xC7, 0xE8, 0),
                                                    SKColors.Transparent },
                                    new float[] { 0.45f, 0.55f, 1 },
                                    SKShaderTileMode.Clamp);

                // Get the blend mode from the picker
                paint.BlendMode = blendModePicker.SelectedIndex == -1 ? 0 :
                                        (SKBlendMode)blendModePicker.SelectedItem;

                canvas.DrawRect(rect, paint);

                // Stroke surrounding rectangle
                paint.Shader = null;
                paint.BlendMode = SKBlendMode.SrcOver;
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Black;
                paint.StrokeWidth = 3;
                canvas.DrawRect(rect, paint);
            }


            /*
                        // Make display rectangle a little smaller than the canvas
                        SKRect rect = info.Rect;
                        rect.Inflate(-20, -20);

                        using (SKPaint paint = new SKPaint())
                        {
                            // Get the blend mode from the picker
                            paint.BlendMode = blendModePicker.SelectedIndex == -1 ? 0 :
                                                    (SKBlendMode)blendModePicker.SelectedItem;

                            // Display destination and source bitmaps
                            canvas.DrawBitmap(dstBitmap, rect, BitmapStretch.Uniform);
                            canvas.DrawBitmap(srcBitmap, rect, BitmapStretch.Uniform,
                                              BitmapAlignment.Center, BitmapAlignment.Center,
                                              paint);
                        }
            */




        }
    }
}