using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
	public class GradientBitmapPage : ContentPage
	{
        SKBitmap bitmap;

        public GradientBitmapPage ()
		{
            Title = "Gradient Bitmap";

            bitmap = new SKBitmap(256, 256);




                        IntPtr pixelsAddr = bitmap.GetPixels();

                        unsafe
            {
                byte* ptr = (byte*)pixelsAddr.ToPointer();

                for (int row = 0; row < 256; row++)
                {
                    for (int col = 0; col < 256; col++)
                    {
                        *ptr++ = (byte)col;     // red
                        *ptr++ = 0;             // green
                        *ptr++ = (byte)row;     // blue
                        *ptr++ = 0xFF;          // alpha
                    }
                }
            }
            /*
                        byte[,,] buffer = new byte[256, 256, 4];

                        for (int row = 0; row < 256; row++)
                        {
                            for (int col = 0; col < 256; col++)
                            {
                                buffer[row, col, 0] = (byte)col;
                                buffer[row, col, 1] = 0;
                                buffer[row, col, 2] = (byte)row;
                                buffer[row, col, 3] = 0xFF;

                        //        buffer[4 * (256 * row + col) + 0] = (byte)col;     // red
                          //      buffer[4 * (256 * row + col) + 1] = 0;             // green
                            //    buffer[4 * (256 * row + col) + 2] = (byte)row;     // blue
                              //  buffer[4 * (256 * row + col) + 3] = 0xFF;          // alpha
                            }
                        }

                        unsafe
                        {
                            fixed (byte* ptr = buffer)
                            {
                                bitmap.SetPixels((IntPtr)ptr);
                            }
                        }

            */

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
            canvas.DrawBitmap(bitmap, info.Rect);
        }
    }
}