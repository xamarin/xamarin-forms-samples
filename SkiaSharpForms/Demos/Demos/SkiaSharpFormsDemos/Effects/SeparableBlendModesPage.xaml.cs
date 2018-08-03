using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
    public partial class SeparableBlendModesPage : ContentPage
    {
        SKBitmap bitmap = BitmapExtensions.LoadBitmapResource(
                            typeof(SeparableBlendModesPage),
                            "SkiaSharpFormsDemos.Media.MountainClimbers.jpg");


        SKBitmap redBitmap = new SKBitmap(256, 256);
        SKBitmap grayBitmap = new SKBitmap(256, 256);
        SKBitmap resultBitmap = new SKBitmap(256, 256);

        public SeparableBlendModesPage()
        {
            InitializeComponent();

            for (int x = 0; x < 256; x++)
                for (int y = 0; y < 256; y++)
                {
                    redBitmap.SetPixel(x, y, new SKColor((byte)x, 0, 0));
                    grayBitmap.SetPixel(x, y, new SKColor((byte)y, (byte)y, (byte)y));
                }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            canvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();




            //    canvas.DrawBitmap(bitmap, info.Rect, BitmapStretch.Uniform);


            canvas.DrawBitmap(redBitmap, new SKRect(0, 0, info.Width / 2 - 10, info.Height), BitmapStretch.Uniform);

            // Get values from XAML controls
            SKBlendMode blendMode =
                (SKBlendMode)(blendModePicker.SelectedIndex == -1 ?
                                            0 : blendModePicker.SelectedItem);


            for (int x = 0; x < 256; x++)
                for (int y = 0; y < 256; y++)
                {
                    SKColor dst = redBitmap.GetPixel(x, y);
                    float dstRed = dst.Red / 255f;
                    float dstGreen = dst.Green / 255f;
                    float dstBlue = dst.Blue / 255f;
                    float dstAlpha = dst.Alpha / 255f;

                    SKColor src = grayBitmap.GetPixel(x, y);
                    float srcRed = src.Red / 255f;
                    float srcGreen = src.Green / 255f;
                    float srcBlue = src.Blue / 255f;
                    float srcAlpha = src.Alpha / 255f;

                    float resRed = 0;
                    float resGreen = 0;
                    float resBlue = 0;

                    switch (blendMode)
                    {
                        case SKBlendMode.ColorBurn:  // OK!                   // Not at all
                                                                        //             resRed = 1 - (1 - dstRed) / srcRed;
                                                                        //           resGreen = 1 - (1 - dstGreen) / srcGreen;
                                                                        //         resBlue = 1 - (1 - dstBlue) / srcBlue;
                            resRed = ColorBurn(dstRed, dstAlpha, srcRed, srcAlpha);
                            resGreen = ColorBurn(dstGreen, dstAlpha, srcGreen, srcAlpha);
                            resBlue = ColorBurn(dstBlue, dstAlpha, srcBlue, srcAlpha);


                            break;

                        case SKBlendMode.ColorDodge:                    // Need to clamp
                            resRed = dstRed / (1 - srcRed);
                            resGreen = dstGreen / (1 - srcGreen);
                            resBlue = dstBlue / (1 - srcBlue);
                            break;

                        case SKBlendMode.Darken:
                            resRed = Math.Min(dstRed, srcRed);
                            resGreen = Math.Min(dstGreen, srcGreen);
                            resBlue = Math.Min(dstBlue, srcBlue);
                            break;

                        case SKBlendMode.Difference:

                            //                            "%s.rgb = %s.rgb + %s.rgb -"
                            //                                 "2.0 * min(%s.rgb * %s.a, %s.rgb * %s.a);",
                            //                               outputColor, srcColor, dstColor, srcColor, dstColor,
                            //                             dstColor, srcColor);


                            resRed = src.Red + dst.Red - 2 * Math.Min(src.Red * dst.Alpha, dst.Red * src.Alpha);
                            resGreen = src.Green + dst.Green - 2 * Math.Min(src.Green * dst.Alpha, dst.Green * src.Alpha);
                            resBlue = src.Blue + dst.Blue - 2 * Math.Min(src.Blue * dst.Alpha, dst.Blue * src.Alpha);

                            //  Math.Max(0, dstRed - srcRed);
                            //  resGreen = Math.Max(0, dstGreen - srcGreen);
                            //  resBlue = Math.Max(0, dstBlue - srcBlue);
                            break;

                        case SKBlendMode.Exclusion:                             // OK
                            resRed = dstRed + srcRed - 2 * dstRed * srcRed;
                            resGreen = dstGreen + srcGreen - 2 * dstGreen * srcGreen;
                            resBlue = dstBlue + srcBlue - 2 * dstBlue * srcBlue;

                            //       "%s.rgb = %s.rgb + %s.rgb - "
                            //            "2.0 * %s.rgb * %s.rgb;",
                            //          outputColor, dstColor, srcColor, dstColor, srcColor);
                            break;

                        case SKBlendMode.HardLight:         // OK
                            /*

                                      fsBuilder->codeAppendf("if (2.0 * %s.%c <= %s.a) {", src, component, src);
                                    fsBuilder->codeAppendf("%s.%c = 2.0 * %s.%c * %s.%c;",
                                                           final, component, src, component, dst, component);
                                    fsBuilder->codeAppend("} else {");
                                    fsBuilder->codeAppendf("%s.%c = %s.a * %s.a - 2.0 * (%s.a - %s.%c) * (%s.a - %s.%c);",
                                                           final, component, src, dst, dst, dst, component, src, src,
                                                           component);
                                    fsBuilder->codeAppend("}");
                                }
                                fsBuilder->codeAppendf("%s.rgb += %s.rgb * (1.0 - %s.a) + %s.rgb * (1.0 - %s.a);",
                                  final, src, dst, dst, src);
                            */

                            resRed = HardLight(dstRed, dstAlpha, srcRed, srcAlpha);
                            resGreen = HardLight(dstGreen, dstAlpha, srcGreen, srcAlpha);
                            resBlue = HardLight(dstBlue, dstAlpha, srcBlue, srcAlpha);

                            resRed += src.Red * (1 - dstAlpha) + dst.Red * (1 - srcAlpha);
                            resGreen += src.Green * (1 - dstAlpha) + dst.Green * (1 - srcAlpha);
                            resBlue += src.Blue * (1 - dstAlpha) + dst.Blue * (1 - srcAlpha);


                            break;

                        case SKBlendMode.Lighten:
                            resRed = Math.Max(dstRed, srcRed);
                            resGreen = Math.Max(dstGreen, srcGreen);
                            resBlue = Math.Max(dstBlue, srcBlue);
                            break;

                        case SKBlendMode.Modulate:

                            break;

                        case SKBlendMode.Multiply:
                            resRed = srcRed * dstRed;
                            resGreen = srcGreen * dstGreen;
                            resBlue = srcBlue * dstBlue;
                            break;

                        case SKBlendMode.Overlay:

                            break;

                        case SKBlendMode.Screen:
                            resRed = 1 - (1 - srcRed) * (1 - dstRed);
                            resGreen = 1 - (1 - srcGreen) * (1 - dstGreen);
                            resBlue = 1 - (1 - srcBlue) * (1 - dstBlue);
                            break;

                        case SKBlendMode.SoftLight:


                            break;

                    }

                    SKColor result = new SKColor((byte)(255 * resRed),
                                                 (byte)(255 * resGreen),
                                                 (byte)(255 * resBlue));

                    resultBitmap.SetPixel(x, y, result);

                }




            float grayShade = (float)grayShadeSlider.Value;

            using (SKPaint paint = new SKPaint())
            {
         //       paint.Color = SKColor.FromHsl(0, 0, 100 * grayShade);
                paint.BlendMode = blendMode;

                //       canvas.DrawRect(info.Rect, paint);

                canvas.DrawBitmap(grayBitmap, new SKRect(0, 0, info.Width / 2 - 10, info.Height),
                    
                    BitmapStretch.Uniform, BitmapAlignment.Center, BitmapAlignment.Center, paint);

            }
            canvas.DrawBitmap(resultBitmap, new SKRect(info.Width / 2 + 10, 0, info.Width, info.Height), BitmapStretch.Uniform);
        }

        float ColorBurn(float dst, float dstAlpha, float src, float srcAlpha)
        {
            /*
                fsBuilder->codeAppendf("if (%s.a == %s.%c) {", dst, dst, component);
                fsBuilder->codeAppendf("%s.%c = %s.a * %s.a + %s.%c * (1.0 - %s.a) + %s.%c * (1.0 - %s.a);",
                                       final, component, src, dst, src, component, dst, dst, component,
                                       src);
                fsBuilder->codeAppendf("} else if (0.0 == %s.%c) {", src, component);
                fsBuilder->codeAppendf("%s.%c = %s.%c * (1.0 - %s.a);",
                                       final, component, dst, component, src);
                fsBuilder->codeAppend("} else {");
                fsBuilder->codeAppendf("float d = max(0.0, %s.a - (%s.a - %s.%c) * %s.a / %s.%c);",
                                       dst, dst, dst, component, src, src, component);
                fsBuilder->codeAppendf("%s.%c = %s.a * d + %s.%c * (1.0 - %s.a) + %s.%c * (1.0 - %s.a);",
                                       final, component, src, src, component, dst, dst, component, src);
                fsBuilder->codeAppend("}"); 
            */

            float output = 0;

            if (dstAlpha == dst)
            {
                output = srcAlpha * dstAlpha + src * (1 - dstAlpha) + dst * (1 - srcAlpha);
            }
            else if (0.0 == src)
            {
                output = dst * (1 - srcAlpha);
            }
            else
            {
                float d = Math.Max(0, dstAlpha - (dstAlpha - dst) * srcAlpha / src);
                output = srcAlpha * d + src * (1 - dstAlpha) + dst * (1 - srcAlpha);
            }


            return output;
        }

        float HardLight(float dst, float dstAlpha, float src, float srcAlpha)
        {
            /*
                        fsBuilder->codeAppendf("if (2.0 * %s.%c <= %s.a) {", src, component, src);
                        fsBuilder->codeAppendf("%s.%c = 2.0 * %s.%c * %s.%c;",
                                               final, component, src, component, dst, component);
                        fsBuilder->codeAppend("} else {");
                        fsBuilder->codeAppendf("%s.%c = %s.a * %s.a - 2.0 * (%s.a - %s.%c) * (%s.a - %s.%c);",
                                               final, component, src, dst, dst, dst, component, src, src,
                                               component);
                        fsBuilder->codeAppend("}");
            */
            float output = 0;

            if (2 * src <= srcAlpha)
            {
                output = 2 * src * dst;
            }
            else
            {
                output = srcAlpha * dstAlpha - 2 * (dstAlpha - dst) * (srcAlpha - src);
            }

            return output;
        }
    }
}
