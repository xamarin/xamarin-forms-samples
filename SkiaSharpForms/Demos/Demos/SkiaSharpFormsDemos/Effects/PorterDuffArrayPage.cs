using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
	public class PorterDuffArrayPage : ContentPage
	{
        static SKBitmap srcBitmap, dstBitmap;

        static PorterDuffArrayPage()
        {
            dstBitmap = new SKBitmap(300, 300);
            srcBitmap = new SKBitmap(300, 300);

            using (SKPaint paint = new SKPaint())
            {
                using (SKCanvas canvas = new SKCanvas(dstBitmap))
                {
                    canvas.Clear();
                    paint.Color = new SKColor(0xC0, 0x80, 0x00); //  0xFF, 0xDC, 0x01);
                    canvas.DrawRect(new SKRect(0, 0, 200, 200), paint);
                }
                using (SKCanvas canvas = new SKCanvas(srcBitmap))
                {
                    canvas.Clear();
                    paint.Color = new SKColor(0x00, 0x80, 0xC0); //  (0x68, 0xC7, 0xE8);
                    canvas.DrawRect(new SKRect(100, 100, 300, 300), paint);
                }
            }
        }

        class BlendModeCanvasView : SKCanvasView
        {
            SKBlendMode blendMode;

            public BlendModeCanvasView(SKBlendMode blendMode)
            {
                this.blendMode = blendMode;
            }

            protected override void OnPaintSurface(SKPaintSurfaceEventArgs args)
            {
                SKImageInfo info = args.Info;
                SKSurface surface = args.Surface;
                SKCanvas canvas = surface.Canvas;

                canvas.Clear();
/*
                using (SKPaint paint = new SKPaint())
                {
                    paint.Shader = SKShader.CreateLinearGradient(new SKPoint(0, 0),
                                                                 new SKPoint(info.Width, 0),
                                                                 new SKColor[] { new SKColor(0xFF, 0xDC, 0x01),
                                                                                 new SKColor(0xFF, 0xDC, 0x01, 0) },
                                                                 new float[] { 0.5f, 0.75f },
                                                                 SKShaderTileMode.Clamp);
                    canvas.DrawRect(info.Rect, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.Shader = SKShader.CreateLinearGradient(new SKPoint(info.Width, 0),
                                                                 new SKPoint(0, 0),
                                                                 new SKColor[] { new SKColor(0x68, 0xC7, 0xE8),
                                                                                 new SKColor(0x68, 0xC7, 0xE8, 0) },
                                                                 new float[] { 0.5f, 0.75f },
                                                                 SKShaderTileMode.Clamp);
                    paint.BlendMode = blendMode;
                    canvas.DrawRect(info.Rect, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.Style = SKPaintStyle.Stroke;
                    paint.Color = SKColors.Black;
                    paint.StrokeWidth = 2;
                    info.Rect.Inflate(-2, -2);
                    canvas.DrawRect(info.Rect, paint);
                }

                return;
*/
                float rectSize = Math.Min(info.Width, info.Height);
                float x = (info.Width - rectSize) / 2;
                float y = (info.Height - rectSize) / 2;
                SKRect rect = new SKRect(x, y, x + rectSize, y + rectSize);

                // Draw destination bitmap
                canvas.DrawBitmap(dstBitmap, rect);

                // Draw source bitmap
                using (SKPaint paint = new SKPaint())
                {
                    paint.BlendMode = blendMode;
                    canvas.DrawBitmap(srcBitmap, rect, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.Style = SKPaintStyle.Stroke;
                    paint.Color = SKColors.Black;
                    paint.StrokeWidth = 2;
                    rect.Inflate(-1, -1);
                    canvas.DrawRect(rect, paint);
                }
            }
        }

        SKBlendMode[] blendModes =
        {
            SKBlendMode.Src, SKBlendMode.Dst, SKBlendMode.SrcOver, SKBlendMode.DstOver,
            SKBlendMode.SrcIn, SKBlendMode.DstIn, SKBlendMode.SrcOut, SKBlendMode.DstOut,
            SKBlendMode.SrcATop, SKBlendMode.DstATop, SKBlendMode.Xor, SKBlendMode.Plus,
            SKBlendMode.Modulate, SKBlendMode.Clear
        };

        public PorterDuffArrayPage ()
		{
            Title = "Porter-Duff Array";

            Grid grid = new Grid
            {
                Margin = new Thickness(5)
            };

            for (int row = 0; row < 4; row++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            }

            for (int col = 0; col < 3; col++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            for (int i = 0; i < blendModes.Length; i++)
            {
                SKBlendMode blendMode = blendModes[i];
                int row = 2 * (i / 4);
                int col = i % 4;

                Label label = new Label
                {
                    Text = blendMode.ToString(),
                    HorizontalTextAlignment = TextAlignment.Center
                };
                Grid.SetRow(label, row);
                Grid.SetColumn(label, col);
                grid.Children.Add(label);

                BlendModeCanvasView canvasView = new BlendModeCanvasView(blendMode);

                Grid.SetRow(canvasView, row + 1);
                Grid.SetColumn(canvasView, col);
                grid.Children.Add(canvasView);
            }

            Content = grid;
		}
    }
}