using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.IO;
using System.Collections.Generic;

namespace SkiaSharpFormsDemos.Bitmaps
{
	public partial class MandelbrotAnimationPage : ContentPage
	{
        //   static readonly Complex center = new Complex(-0.774693089457127, 0.124226621261617);
        const int COUNT = 50;
        //    static readonly Complex center = new Complex(-0.556624880053304, 0.634696788141351);

        static readonly Complex center = new Complex(-1.17651152924355, 0.298520986549558);

        SKBitmap currentBitmap;
        int currentIndex;
    //    SKBitmap nextBitmap;
        Stopwatch stopwatch = new Stopwatch();


        List<SKBitmap> bitmaps = new List<SKBitmap>();

        SKRect sourceRect = new SKRect(0, 0, 1000, 1000);

		public MandelbrotAnimationPage ()
		{
			InitializeComponent ();

            Doit();
		}

        string Filepath(int zoomLevel) => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                                       String.Format("Mandelbrot-R{0}I{1}Z{2:D2}.png", center.Real, center.Imaginary, zoomLevel));

        async void Doit()
        {
            string localData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            for (int zoomLevel = 0; zoomLevel < COUNT; zoomLevel++)
            {
//                 string filepath = Path.Combine(localData, String.Format("Mandelbrot{0:D2}.png", zoomLevel));

                if (File.Exists(Filepath(zoomLevel)))
                {
                    continue;
                }

                label.Text = "Creating bitmap for zoom level " + zoomLevel;

                Progress<double> progressReporter = new Progress<double>((double progress) =>
                {
                    progressBar.Progress = progress;
                });

                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                CancellationToken cancelToken = cancelTokenSource.Token;

                BitmapInfo bitmapInfo = await Mandelbrot.CalculateAsync(center,
                                                                        4 / Math.Pow(2, zoomLevel),
                                                                        4 / Math.Pow(2, zoomLevel), 1000, 1000, (int)Math.Pow(2, 10), progressReporter, cancelToken);

                SKBitmap bitmap = new SKBitmap(1000, 1000, SKColorType.Rgba8888, SKAlphaType.Opaque);

                //      byte[] bits = new byte[1000 * 1000 * 4];

                //    IntPtr ptr = *bits;

                

           //     using (new SKAutoLockPixels(bitmap))
                {



                    IntPtr ptrBase = bitmap.GetPixels();

                    for (int row = 0; row < 1000; row++)
                        for (int col = 0; col < 1000; col++)
                        {
                            int iterationCount = bitmapInfo.IterationCounts[1000 * row + col];
                            uint pixel = 0xFF000000;            // black

                            if (iterationCount != -1)
                            {
                                double proportion = (iterationCount / 32.0) % 1;
                                byte red = 0, green = 0, blue = 0;

                                if (proportion < 0.5)
                                {
                                    red = (byte)(255 * (1 - 2 * proportion));
                                    blue = (byte)(255 * 2 * proportion);
                                }
                                else
                                {
                                    proportion = 2 * (proportion - 0.5);
                                    green = (byte)(255 * proportion);
                                    blue = (byte)(255 * (1 - proportion));
                                }


                                pixel = MakePixel(0xFF, red, green, blue);
                            }

                            IntPtr ptrPixel = ptrBase + 4 * (1000 * row + col);

                            unsafe
                            {
                                *(uint*)ptrPixel.ToPointer() = pixel;
                            }
                        }
                }
                SKData data = SKImage.FromBitmap(bitmap).Encode();      // PNG

                File.WriteAllBytes(Filepath(zoomLevel), data.ToArray());

                currentBitmap = bitmap;
                canvasView.InvalidateSurface();
            }

      //      int count = 0;

            for (int zoomLevel = 0; zoomLevel < 100; zoomLevel++)
            {
          //      string filepath = Path.Combine(localData, String.Format("Mandelbrot{0:D2}.png", zoomLevel));

                if (!File.Exists(Filepath(zoomLevel)))
                    break;

                label.Text = "Loading bitmap for zoom level " + zoomLevel;

                using (Stream stream = File.OpenRead(Filepath(zoomLevel)))
                {
                    bitmaps.Add(SKBitmap.Decode(stream));
                }

           //     bitmaps.Add()

           //     count++;
            }

            int count = bitmaps.Count;

            stopwatch.Start();
            int cycle = 6000 * count;      // milliseconds
            currentIndex = -1;

            while (true)
            {
                long msec = stopwatch.ElapsedMilliseconds;
                int time = (int)(msec % cycle);
                double progress = count * 0.5 * (1 + Math.Sin(2 * Math.PI * time / cycle - Math.PI / 2));

         //       Debug.WriteLine(progress);

                int index = (int)progress;

                if (index != currentIndex)
                {
            //        Debug.WriteLine("--------------------------- Loading {0}", index);
                    currentIndex = index;
                    //    string filepath = Path.Combine(localData, String.Format("Mandelbrot{0:D2}.png", index));
                    /*
                                        using (Stream stream = File.OpenRead(Filepath(index)))
                                        {
                                            currentBitmap = SKBitmap.Decode(stream);
                                        }
                    */
                    currentBitmap = bitmaps[index];


                    label.Text = "Displaying bitmap for zoom level " + index;

                }

                float fraction = (float)(progress - index);

                progressBar.Progress = fraction;

                sourceRect = new SKRect(fraction * 250, fraction * 250,
                                        1000 - fraction * 250, 1000 - fraction * 250);

                canvasView.InvalidateSurface();

                await Task.Delay(16);
            }
        }

        uint MakePixel(byte alpha, byte red, byte green, byte blue)
        {
            return (uint)((alpha << 24) | (blue << 16) | (green << 8) | red);
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            if (currentBitmap != null)
            {
                int dim = Math.Min(info.Width, info.Height);
                float x = (info.Width - dim) / 2;
                float y = (info.Height - dim) / 2;
                SKRect destRect = new SKRect(x, y, x + dim, y + dim);

                canvas.DrawBitmap(currentBitmap, sourceRect, destRect);
            }
        }
    }
}