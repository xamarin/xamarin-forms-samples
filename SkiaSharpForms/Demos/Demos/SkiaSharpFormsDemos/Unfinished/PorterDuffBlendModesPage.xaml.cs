using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
    public partial class PorterDuffBlendModesPage : ContentPage
    {
        const int BitmapSize = 300;
        const int TextSize = 400;

        SKBitmap dstBitmap;
        SKBitmap srcBitmap;

        public PorterDuffBlendModesPage()
        {
            InitializeComponent();

            dstBitmap = new SKBitmap(BitmapSize, BitmapSize);
            srcBitmap = new SKBitmap(BitmapSize, BitmapSize);

            IntPtr dstPtr0 = dstBitmap.GetPixels();
            IntPtr srcPtr0 = srcBitmap.GetPixels();

            for (int row = 0; row < BitmapSize; row++)
                for (int col = 0; col < BitmapSize; col++)
                {
                    bool isDstOpaque = row < 2 * BitmapSize / 3 && col < 2 * BitmapSize / 3;
                    bool isSrcOpaque = row > BitmapSize / 3 && col > BitmapSize / 3;

                    IntPtr dstPtr = dstPtr0 + 4 * (BitmapSize * row + col);
                    IntPtr srcPtr = srcPtr0 + 4 * (BitmapSize * row + col);

                    unsafe
                    {
                        *(uint*)dstPtr.ToPointer() = isDstOpaque ? 0xFFFF0000 : 0; //  0xFFFFE000 : 0;
                        *(uint*)srcPtr.ToPointer() = isSrcOpaque ? 0xFF0000FF : 0; //  0xFF00FFFF : 0;
                    }
                }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            /*


                        SKBlendMode[] modes = {
                    SKBlendMode.Clear,
                    SKBlendMode.Src,
                    SKBlendMode.Dst,
                    SKBlendMode.SrcOver,
                    SKBlendMode.DstOver,
                    SKBlendMode.SrcIn,
                    SKBlendMode.DstIn,
                    SKBlendMode.SrcOut,
                    SKBlendMode.DstOut,
                    SKBlendMode.SrcATop,
                    SKBlendMode.DstATop,
                    SKBlendMode.Xor,
                    SKBlendMode.Plus,
                    SKBlendMode.Modulate,
                    SKBlendMode.Screen,
                    SKBlendMode.Overlay,
                    SKBlendMode.Darken,
                    SKBlendMode.Lighten,
                    SKBlendMode.ColorDodge,
                    SKBlendMode.ColorBurn,
                    SKBlendMode.HardLight,
                    SKBlendMode.SoftLight,
                    SKBlendMode.Difference,
                    SKBlendMode.Exclusion,
                    SKBlendMode.Multiply,
                    SKBlendMode.Hue,
                    SKBlendMode.Saturation,
                    SKBlendMode.Color,
                    SKBlendMode.Luminosity,
                };
                        SKRect rect = SKRect.Create(64.0f, 64.0f);
                        SKPaint text = new SKPaint(), stroke = new SKPaint(), src = new SKPaint(), dst = new SKPaint();
                        stroke.Style = SKPaintStyle.Stroke;
                        text.TextSize = 24.0f;
                        text.IsAntialias = true;
                        SKPoint[] srcPoints = {
                    new SKPoint(0.0f, 0.0f),
                    new SKPoint(64.0f, 0.0f)
                };
                        SKColor[] srcColors = {
                            new SKColor(0xFF, 0, 0xFF, 0x0),
                            SKColors.Magenta };
                        src.Shader = SKShader.CreateLinearGradient(srcPoints[0], srcPoints[1], srcColors, null, SKShaderTileMode.Clamp);

                        SKPoint[] dstPoints = {
                    new SKPoint(0.0f, 0.0f),
                    new SKPoint(0.0f, 64.0f)
                };
                        SKColor[] dstColors = { new SKColor(0, 0xFF, 0xFF, 0), SKColors.Cyan};

                        dst.Shader = SKShader.CreateLinearGradient(dstPoints[0], dstPoints[1], dstColors, null, SKShaderTileMode.Clamp);
                        canvas.Clear(SKColors.White);

                  //      int N = sizeof(modes) / sizeof(modes[0]);
                        int K = (modes.Length - 1) / 3 + 1;
            //            SKASSERT(K * 64 == 640);  // tall enough
                        for (int i = 0; i < modes.Length; i++)
                        {
                            using (new SKAutoCanvasRestore(canvas))
                            {
                                canvas.Translate(192.0f * (i / K), 64.0f * (i % K));
                                string desc = modes[i].ToString();
                                canvas.DrawText(desc, 68.0f, 30.0f, text);

                                canvas.ClipRect(SKRect.Create(64.0f, 64.0f));
                                canvas.DrawColor(SKColors.LightGray);
                                canvas.SaveLayer(null);
                         //       canvas.Clear(SKColors.Transparent);
                                canvas.DrawPaint(dst);
                                src.BlendMode = modes[i];
                                canvas.DrawPaint(src);
                                canvas.DrawRect(rect, stroke);
                            }
                    }





                        return;
            */
            canvas.Clear(new SKColor(0, 0, 0, 0));                  // !!!!!!

            int x = (info.Width - BitmapSize) / 2;
            int y = 100;

            canvas.DrawBitmap(dstBitmap, new SKPoint(x, y));

            canvas.DrawBitmap(srcBitmap, new SKPoint(x, y), new SKPaint
            {
                BlendMode = (SKBlendMode)modePicker.SelectedItem
            });


            canvas.DrawRect(x, y, BitmapSize, BitmapSize, new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black
            });


            SKPoint pt = new SKPoint(info.Width / 2, y + BitmapSize + TextSize);

            SKRect rect = new SKRect(0, y + BitmapSize + 50, info.Width, info.Height);

            canvas.ClipRect(rect);

            //     canvas.DrawRect(, new SKPaint { Color = new SKColor(0, 0, 0, 0) });

            canvas.SaveLayer(null);

            canvas.Clear(SKColors.Transparent);

            canvas.DrawText("X", pt, new SKPaint { TextSize = TextSize, TextAlign = SKTextAlign.Center, Color = SKColors.Red /*, BlendMode = (SKBlendMode)modePicker.SelectedItem */ });

            canvas.DrawText("0", pt, new SKPaint { TextSize = TextSize, TextAlign = SKTextAlign.Center, Color = SKColors.Blue, BlendMode = (SKBlendMode)modePicker.SelectedItem });


        }

        void OnModePickerSelectedIndexChanged(object sender, EventArgs args)
        {
            if (canvasView != null)
            {
                canvasView.InvalidateSurface();
            }
        }
    }
}