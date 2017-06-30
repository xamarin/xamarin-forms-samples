using System;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Curves
{
    public class TextPathEffectPage : ContentPage
    {
        static float littleXSize = 50;

        static SKPaint textPathPaint = new SKPaint
        {
            TextSize = littleXSize
        };

        static SKPath textPath;

        static SKPathEffect pathEffect;

        SKPaint textPaint = new SKPaint                     // doesn't need a stroke width
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black
        };

        public TextPathEffectPage()
        {
            Title = "Text Path Effect";

            // Get the bounds of textPathPaint
            SKRect textPathPaintBounds;
            textPathPaint.MeasureText("X", ref textPathPaintBounds);

            // Create textPath centered around (0, 0)
            textPath = textPathPaint.GetTextPath("X", -textPathPaintBounds.MidX, 
                                                      -textPathPaintBounds.MidY);

            // Create the path effect
            pathEffect = SKPathEffect.Create1DPath(textPath, littleXSize, 0,
                                                SKPath1DPathEffectStyle.Translate);

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Adjust textPaint textSize based on screen size
            textPaint.TextSize = Math.Min(1.6f * info.Width, 1.3f * info.Height);

            // Do not measure the text with PathEffect set!                             // !!!!!!
            SKRect textBounds;
            textPaint.MeasureText("X", ref textBounds);

            // Coordinates to center text on screen
            float xText = info.Width / 2 - textBounds.MidX;
            float yText = info.Height / 2 - textBounds.MidY;

            // Set the PathEffect property and display text
            textPaint.PathEffect = pathEffect;
            canvas.DrawText("X", xText, yText, textPaint);
        }
    }
}

