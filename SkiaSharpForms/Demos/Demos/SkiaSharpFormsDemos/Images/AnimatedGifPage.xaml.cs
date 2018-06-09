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

                // Note: There's also a RepetitionCount property of SKCodec not used here

                // Loop through the frames
                for (int frame = 0; frame < frameCount; frame++)
                {
                    // From the FrameInfo collection, get the duration of each frame
                    durations[frame] = codec.FrameInfo[frame].Duration;

                    // Create a full-color bitmap for each frame
                    SKImageInfo imageInfo = new SKImageInfo(codec.Info.Width, codec.Info.Height);
                    bitmaps[frame] = new SKBitmap(imageInfo);

                    // Get the address of the pixels in that bitmap
                    IntPtr pointer = bitmaps[frame].GetPixels();

                    // Create an SKCodecOptions value to specify the frame
                    SKCodecOptions codecOptions = new SKCodecOptions(frame, false);

                    // Copy pixels from the frame into the bitmap
                    codec.GetPixels(imageInfo, pointer, codecOptions);
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
            }

            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);

        }


        // TODO: Appearing and Disappearing !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


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
            
/*
            float width = info.Width / 6;
            float height = info.Height / 6;

            for (int frame = 0; frame < bitmaps.Length; frame++)
            {
                float x = (frame % 6) * width;
                float y = (frame / 6) * height;

                SKRect rect = new SKRect(x, y, x + width, y + height);

                try
                {
                    canvas.DrawBitmap(bitmaps[frame], rect);
                }
                catch (Exception exc)
                {
                    Debug.WriteLine("frame {0} {1}", frame, exc);
                }
            }
*/
        }
    }
}