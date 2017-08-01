using System;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Curves
{
    public class CharacterOutlineOutlinesPage : ContentPage
    {
        public CharacterOutlineOutlinesPage()
        {
            Title = "Character Outline Outlines";

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

            using (SKPaint textPaint = new SKPaint())
            {
                textPaint.Style = SKPaintStyle.Stroke;

                // Set textPaint textSize based on screen size
                textPaint.TextSize = Math.Min(info.Width, info.Height);

                SKRect textBounds;
                textPaint.MeasureText("@", ref textBounds);

                // Coordinates to center text on screen
                float xText = info.Width / 2 - textBounds.MidX;
                float yText = info.Height / 2 - textBounds.MidY;


                //   textPaint.StrokeWidth = 20;

                using (SKPath textPath = textPaint.GetTextPath("@", xText, yText))
                {
                    using (SKPath outlinePath = new SKPath())
                    {
                        textPaint.StrokeWidth = 25;

                        textPaint.GetFillPath(textPath, outlinePath);

                        using (SKPaint outlinePaint = new SKPaint())
                        {
                            outlinePaint.Style = SKPaintStyle.Stroke;
                            outlinePaint.StrokeWidth = 5;
                            outlinePaint.Color = SKColors.Red;

                            canvas.DrawPath(outlinePath, outlinePaint);
                        }
                    }


                }


            }
        }
    }
}