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


            }

            // Draw brick wall behind monkey
            using (SKPaint paint = new SKPaint())
            {
                // Create bitmap tiling
                paint.Shader = SKShader.CreateBitmap(AlgorithmicBrickWallPage.BrickWallTile,
                                                     SKShaderTileMode.Repeat,
                                                     SKShaderTileMode.Repeat);
                paint.BlendMode = SKBlendMode.DstOver;

                canvas.DrawRect(info.Rect, paint);
            }
        }
    }
}