using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
    // TODO: Need TouchEffect to get taps

    // TODO: Refine bitmap colors

    // TODO: Need some margin between text and edges


    public class NinePatchButton : ContentView
    {
        const int PATCH_SIZE = 20;
        const int BITMAP_SIZE = 3 * PATCH_SIZE;
        static readonly SKRectI centerRect =
            new SKRectI(PATCH_SIZE, PATCH_SIZE, 
                        BITMAP_SIZE - PATCH_SIZE, BITMAP_SIZE - PATCH_SIZE);

        SKCanvasView canvasView;
        SKBitmap bitmapReleased;
        SKBitmap bitmapPressed;
        bool buttonPressed = false;

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(NinePatchButton), "",
                                    propertyChanged: (bindable, oldValue, newValue) => 
                                        ((NinePatchButton)bindable).InvalidateMeasure());
                                    

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(double), typeof(NinePatchButton), 24.0,
                                    propertyChanged: (bindable, oldValue, newValue) =>
                                        ((NinePatchButton)bindable).InvalidateMeasure());

        SKPaint textPaint = new SKPaint();

        public NinePatchButton ()
        {
            // Create two bitmaps
            bitmapReleased = new SKBitmap(BITMAP_SIZE, BITMAP_SIZE);
            bitmapPressed = new SKBitmap(BITMAP_SIZE, BITMAP_SIZE);

            using (SKPath pathUL = new SKPath())
            using (SKPath pathLR = new SKPath())
            {
                // Upper-left edge of button
                pathUL.MoveTo(0, 0);
                pathUL.LineTo(BITMAP_SIZE, 0);
                pathUL.LineTo(BITMAP_SIZE - PATCH_SIZE, PATCH_SIZE);
                pathUL.LineTo(PATCH_SIZE, PATCH_SIZE);
                pathUL.LineTo(PATCH_SIZE, BITMAP_SIZE - PATCH_SIZE);
                pathUL.LineTo(0, BITMAP_SIZE);
                pathUL.Close();

                // Lower-right edge of button
                pathLR.MoveTo(BITMAP_SIZE, BITMAP_SIZE);
                pathLR.LineTo(0, BITMAP_SIZE);
                pathLR.LineTo(PATCH_SIZE, BITMAP_SIZE - PATCH_SIZE);
                pathLR.LineTo(BITMAP_SIZE - PATCH_SIZE, BITMAP_SIZE - PATCH_SIZE);
                pathLR.LineTo(BITMAP_SIZE - PATCH_SIZE, PATCH_SIZE);
                pathLR.LineTo(BITMAP_SIZE, 0);
                pathLR.Close();

                using (SKPaint pathPaint = new SKPaint())
                {
                    using (SKCanvas canvas = new SKCanvas(bitmapReleased))
                    {
                        canvas.Clear(new SKColor(0x80, 0x80, 0x80));

                        pathPaint.Color = new SKColor(0xC0, 0xC0, 0xC0);
                        canvas.DrawPath(pathUL, pathPaint);

                        pathPaint.Color = new SKColor(0x40, 0x40, 0x40);
                        canvas.DrawPath(pathLR, pathPaint);
                    }
                    using (SKCanvas canvas = new SKCanvas(bitmapPressed))
                    {
                        canvas.Clear(new SKColor(0x80, 0x80, 0x80));

                        pathPaint.Color = new SKColor(0x40, 0x40, 0x40);
                        canvas.DrawPath(pathUL, pathPaint);

                        pathPaint.Color = new SKColor(0xC0, 0xC0, 0xC0);
                        canvas.DrawPath(pathLR, pathPaint);
                    }
                }
            }

            // Create SKCanvasView
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;    
        }

        public string Text
        {
            set { SetValue(TextProperty, value); }
            get { return (string)GetValue(TextProperty); }
        }

        public double FontSize
        {
            set { SetValue(FontSizeProperty, value); }
            get { return (double)GetValue(FontSizeProperty); }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawBitmapNinePatch(buttonPressed ? bitmapPressed : bitmapReleased,
                                       centerRect, info.Rect);

            SKRect textBounds = new SKRect();
            textPaint.MeasureText(Text, ref textBounds);
            float xText = info.Width / 2 - textBounds.MidX;
            float yText = info.Height / 2 - textBounds.MidY;
            canvas.DrawText(Text, xText, yText, textPaint);
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            textPaint.TextSize = (float)FontSize;
            SKRect bounds = new SKRect();
            textPaint.MeasureText(Text, ref bounds);

            // TODO: Need to scale from pixels to device-independent units here
            //  but can't use SKCanvasView to do it.
            // Xamarin.Essentials would help, but must wait until it's 1.0.
            // Could do dependency service but would require event to get updated

            float scale = 1; // 3; //  canvasView.CanvasSize.Width / (float)canvasView.Width;


            canvasView.InvalidateSurface();

            return new SizeRequest(new Size((bounds.Width + 2 * PATCH_SIZE) / scale,
                                            (bounds.Height + 2 * PATCH_SIZE) / scale));
        }
    }
}