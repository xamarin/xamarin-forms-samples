using System;
using System.IO;
using System.Reflection;
using SkiaSharp;

namespace SkiaSharpFormsDemos
{
    static class BitmapExtensions
    {
        public static SKBitmap LoadBitmapResource(Type type, string resourceID)
        {
            Assembly assembly = type.GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            using (SKManagedStream skStream = new SKManagedStream(stream))
            {
                return SKBitmap.Decode(skStream);
            }
        }

        public static void DrawBitmap(this SKCanvas canvas, SKBitmap bitmap, SKRect destRect, 
                                      BitmapStretch stretch, 
                                      BitmapAlignment horizontal = BitmapAlignment.Center, 
                                      BitmapAlignment vertical = BitmapAlignment.Center, 
                                      SKPaint paint = null)
        {
            if (stretch == BitmapStretch.Fill)
            {
                canvas.DrawBitmap(bitmap, destRect, paint);
            }
            else
            {
                float scale = 1;

                switch (stretch)
                {
                    case BitmapStretch.None:
                        break;

                    case BitmapStretch.Uniform:
                        scale = Math.Min(destRect.Width / bitmap.Width, destRect.Height / bitmap.Height);
                        break;

                    case BitmapStretch.UniformToFill:
                        scale = Math.Max(destRect.Width / bitmap.Width, destRect.Height / bitmap.Height);
                        break;
                }

                SKRect dispRect = CalculateDisplayRect(destRect, scale * bitmap.Width, scale * bitmap.Height, horizontal, vertical);

                canvas.DrawBitmap(bitmap, dispRect, paint);
            }
        }
        static SKRect CalculateDisplayRect(SKRect destRect, float bmpWidth, float bmpHeight, BitmapAlignment horizontal, BitmapAlignment vertical)
        {
            float x = 0;
            float y = 0;

            switch (horizontal)
            {
                case BitmapAlignment.Center:
                    x = (destRect.Width - bmpWidth) / 2;
                    break;

                case BitmapAlignment.Start:
                    break;

                case BitmapAlignment.End:
                    x = destRect.Width - bmpWidth;
                    break;
            }

            switch (vertical)
            {
                case BitmapAlignment.Center:
                    y = (destRect.Height - bmpHeight) / 2;
                    break;

                case BitmapAlignment.Start:
                    break;

                case BitmapAlignment.End:
                    y = destRect.Height - bmpHeight;
                    break;
            }

            x += destRect.Left;
            y += destRect.Top;

            return new SKRect(x, y, x + bmpWidth, y + bmpHeight);
        }
    }

    public enum BitmapStretch
    {
        None,
        Fill,
        Uniform,
        UniformToFill,
        AspectFit = Uniform,
        AspectFill = UniformToFill
    }

    public enum BitmapAlignment
    {
        Start,
        Center,
        End
    }
}
