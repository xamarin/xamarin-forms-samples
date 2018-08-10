using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
	public partial class BrickWallCompositingPage : ContentPage
	{
        SKBitmap monkeyBitmap = BitmapExtensions.LoadBitmapResource(
            typeof(BrickWallCompositingPage), "SkiaSharpFormsDemos.Media.SeatedMonkey.jpg");

        SKBitmap matteBitmap = BitmapExtensions.LoadBitmapResource(
            typeof(BrickWallCompositingPage), "SkiaSharpFormsDemos.Media.SeatedMonkeyMatte.png");

		public BrickWallCompositingPage ()
		{
			InitializeComponent ();
		}

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Draw monkey bitmap
            float x = (info.Width - monkeyBitmap.Width) / 2;
            float y = info.Height - monkeyBitmap.Height;

            canvas.DrawBitmap(monkeyBitmap, x, y);

            // Draw matte to exclude monkey's surroundings
            using (SKPaint paint = new SKPaint())
            {
                paint.BlendMode = SKBlendMode.DstIn;
                canvas.DrawBitmap(matteBitmap, x, y, paint);
            }

            using (SKPaint paint = new SKPaint())
            {
                const float gravelHeight = 80;

                // Draw gravel ground to monkey to sit on
                paint.Shader = SKShader.CreateCompose(
                                    SKShader.CreateColor(SKColors.SandyBrown),
                                    SKShader.CreatePerlinNoiseTurbulence(0.1f, 0.3f, 1, 9));

                paint.BlendMode = SKBlendMode.DstOver;
                SKRect rect = new SKRect(info.Rect.Left, info.Rect.Bottom - gravelHeight,
                                         info.Rect.Right, info.Rect.Bottom);
                canvas.DrawRect(rect, paint);

                // Draw bitmap tiled brick wall behind monkey
                SKBitmap bitmap = AlgorithmicBrickWallPage.BrickWallTile;
                float yAdjust = (info.Height - gravelHeight) % bitmap.Height;

                paint.Shader = SKShader.CreateBitmap(bitmap,
                                                     SKShaderTileMode.Repeat,
                                                     SKShaderTileMode.Repeat,
                                                     SKMatrix.MakeTranslation(0, yAdjust));
                paint.BlendMode = SKBlendMode.DstOver;

                canvas.DrawRect(info.Rect, paint);
            }
        }
    }
}