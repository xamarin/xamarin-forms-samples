using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos
{
    public partial class BlendModesPage : ContentPage
    {
        public BlendModesPage()
        {
            InitializeComponent();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Gray);

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                BlendMode = SKBlendMode.Multiply // ...ColorDodge // .Plus
            };

            SKPoint center = new SKPoint(info.Width / 2, info.Height / 2);
            float radius = 0.25f * Math.Min(info.Width, info.Height);
            float centerSeparation = 0.5f * radius;

            paint.Color = SKColors.Red;
            canvas.DrawCircle(center.X, center.Y - centerSeparation, radius, paint);

            paint.Color = new SKColor(0, 255, 0);
            canvas.DrawCircle(center.X - (float)Math.Cos(Math.PI / 6) * centerSeparation,
                              center.Y + (float)Math.Sin(Math.PI / 6) * centerSeparation, radius, paint);

            paint.Color = SKColors.Blue;
            canvas.DrawCircle(center.X + (float)Math.Cos(Math.PI / 6) * centerSeparation,
                              center.Y + (float)Math.Sin(Math.PI / 6) * centerSeparation, radius, paint);
        }
    }
}
