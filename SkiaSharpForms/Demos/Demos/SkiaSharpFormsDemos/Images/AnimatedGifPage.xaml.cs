using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Images
{
	public partial class AnimatedGifPage : ContentPage
	{
        SKBitmap[] bitmaps;
        int[] durations;
        int[] accumulatedDurations;
        int totalDuration;

        Stopwatch stopwatch = new Stopwatch();

        int currentFrame;

		public AnimatedGifPage ()
		{
			InitializeComponent ();




            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += (sender, args) =>
            {

                currentFrame += 1;

                canvasView.InvalidateSurface();

            };
          






            /*
                        string resourceID = "SkiaSharpFormsDemos.Media.monkey.png";
                        Assembly assembly = GetType().GetTypeInfo().Assembly;

                        using (Stream stream = assembly.GetManifestResourceStream(resourceID))
                        using (SKManagedStream skStream = new SKManagedStream(stream))
                        {
                            resourceBitmap = SKBitmap.Decode(skStream);
                        }
            */

            string resourceID = "SkiaSharpFormsDemos.Media.Newtons_cradle_animation_book_2.gif";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            using (SKManagedStream skStream = new SKManagedStream(stream))
            {
                SKCodec codec = SKCodec.Create(skStream);

                int frameCount = codec.FrameCount;

                bitmaps = new SKBitmap[frameCount];
                durations = new int[frameCount];
                accumulatedDurations = new int[frameCount];



                int repetitionCount = codec.RepetitionCount;

                System.Diagnostics.Debug.WriteLine("{0} {1}", frameCount, repetitionCount);




                foreach (SKCodecFrameInfo frameInfo in codec.FrameInfo)
                {
                    System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3}", frameInfo.AlphaType, frameInfo.Duration, frameInfo.FullyRecieved, frameInfo.RequiredFrame);

                }

                for (int frame = 0; frame < frameCount; frame++)
                {
                    durations[frame] = codec.FrameInfo[frame].Duration;
                }


                for (int frame = 0; frame < frameCount; frame++)
                {
                    SKCodecOptions codecOptions = new SKCodecOptions(frame, false);

                    SKImageInfo imageInfo = new SKImageInfo(codec.Info.Width, codec.Info.Height);

                    bitmaps[frame] = new SKBitmap(imageInfo); //, imageInfo.ColorType); // , imageInfo.AlphaType);

                    byte[] pixels = new byte[imageInfo.BytesSize];

                    unsafe
                    {
                        fixed (byte* p = pixels)
                        {
                            codec.GetPixels(imageInfo, (IntPtr)p, codecOptions);
                            bitmaps[frame].SetPixels((IntPtr)p);
                        }
                    }

                }

                for (int frame = 0; frame < durations.Length; frame++)
                {
                    totalDuration += durations[frame];
                }


                for (int frame = 0; frame < durations.Length; frame++)
                {
                    accumulatedDurations[frame] = durations[frame] + 
                        (frame == 0 ? 0 : accumulatedDurations[frame - 1]);
                }


//                bitmap = SKBitmap.Decode(codec); // skStream
            }


            stopwatch.Start();
   //         Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);

        }

        bool OnTimerTick()
        {
            int msec = (int)(stopwatch.ElapsedMilliseconds % totalDuration);
            int frame = 0;

            for (frame = 0; frame < accumulatedDurations.Length; frame++)
            {
                if (msec < accumulatedDurations[frame])
                {
                    break;
                }
            }

            System.Diagnostics.Debug.WriteLine(frame);

            currentFrame = frame;
            canvasView.InvalidateSurface();

            return true;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Black);

            SKBitmap bitmap = bitmaps[currentFrame];
            int x = (info.Width - bitmap.Width) / 2;
            int y = (info.Height - bitmap.Height) / 2;

            canvas.DrawBitmap(bitmap, x, y);
        }
    }
}