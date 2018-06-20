using System;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
    class PhotoCropperCanvasView : SKCanvasView
    {
        const int BITMAP_MARGIN = 20;

        SKBitmap bitmap;
        SKRect cropRect;

        SKPaint cornerStroke = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.White,
            StrokeWidth = 10
        };

        SKPaint edgeStroke = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.White,
            StrokeWidth = 2
        };

        public PhotoCropperCanvasView(SKBitmap bitmap)
        {
            this.bitmap = bitmap;

            cropRect = new SKRect(20, 20, bitmap.Width - 20, bitmap.Height - 20);
        }

        public SKBitmap CroppedBitmap
        {
            get
            {
                SKBitmap croppedBitmap = new SKBitmap((int)cropRect.Width, (int)cropRect.Height);
                SKRect dest = new SKRect(0, 0, cropRect.Width, cropRect.Height);
                SKRect source = new SKRect(cropRect.Left, cropRect.Top, cropRect.Right, cropRect.Bottom);

                using (SKCanvas canvas = new SKCanvas(croppedBitmap))
                {
                    canvas.DrawBitmap(bitmap, source, dest);
                }

                return croppedBitmap;
            }
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs args)
        {
            base.OnPaintSurface(args);

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Gray);

            SKRect rectCanvas = info.Rect;
            SKRect rectDisplay = rectCanvas;
            rectDisplay.Inflate(-BITMAP_MARGIN, -BITMAP_MARGIN);

            float scale = Math.Min(rectDisplay.Width / bitmap.Width, rectDisplay.Height / bitmap.Height);
            float x = rectDisplay.Left + (rectDisplay.Width - scale * bitmap.Width) / 2;
            float y = rectDisplay.Top + (rectDisplay.Height - scale * bitmap.Height) / 2;

            SKRect rectBitmap = new SKRect(x, y, x + scale * bitmap.Width, y + scale * bitmap.Height);
            canvas.DrawBitmap(bitmap, rectDisplay, BitmapStretch.Uniform);




            SKMatrix matrix = SKMatrix.MakeIdentity();
            matrix.SetScaleTranslate(scale, scale, x, y);

            SKRect scaledRect = matrix.MapRect(cropRect);
            canvas.DrawRect(scaledRect, edgeStroke);


            using (SKPath path = new SKPath())
            {
                path.MoveTo(scaledRect.Left, scaledRect.Top + 55);
                path.LineTo(scaledRect.Left, scaledRect.Top);
                path.LineTo(scaledRect.Left + 55, scaledRect.Top);

                path.MoveTo(scaledRect.Right - 55, scaledRect.Top);
                path.LineTo(scaledRect.Right, scaledRect.Top);
                path.LineTo(scaledRect.Right, scaledRect.Top + 55);

                path.MoveTo(scaledRect.Right, scaledRect.Bottom - 55);
                path.LineTo(scaledRect.Right, scaledRect.Bottom);
                path.LineTo(scaledRect.Right - 55, scaledRect.Bottom);

                path.MoveTo(scaledRect.Left + 55, scaledRect.Bottom);
                path.LineTo(scaledRect.Left, scaledRect.Bottom);
                path.LineTo(scaledRect.Left, scaledRect.Bottom - 55);

                canvas.DrawPath(path, cornerStroke);
            }










        }
    }
}
