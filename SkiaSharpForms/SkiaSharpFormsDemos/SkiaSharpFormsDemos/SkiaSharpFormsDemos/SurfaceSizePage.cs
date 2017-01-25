using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;


namespace SkiaSharpFormsDemos
{
    public class SurfaceSizePage : ContentPage
    {
        SKCanvasView canvasView;

        public SurfaceSizePage()
        {
            Title = "Surface Size";

            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 50
            };

            float fontSpacing = paint.FontSpacing;
            float x = 20;               // left margin
            float y = fontSpacing;      // first baseline
            float indent = 100;

            canvas.DrawText("Height and Width of SKCanvasView:", x, y, paint);
            y += fontSpacing;
            canvas.DrawText(String.Format("{0} x {1}", canvasView.Width, canvasView.Height), x + indent, y, paint);
            y += fontSpacing * 2;
            canvas.DrawText("CanvasSize of SKCanvasView:", x, y, paint);
            y += fontSpacing;
            canvas.DrawText(canvasView.CanvasSize.ToString(), x + indent, y, paint);
            y += fontSpacing * 2;
            canvas.DrawText("SKImageInfo Size:", x, y, paint);
            y += fontSpacing;
            canvas.DrawText(info.Size.ToString(), x + indent, y, paint);
        }
    }
}
