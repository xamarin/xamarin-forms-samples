using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos
{
    public partial class MultipleLinesPage : ContentPage
    {
        public MultipleLinesPage()
        {
            InitializeComponent();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            if (canvasView != null)
            {
                canvasView.InvalidateSurface();
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 50,
                StrokeCap = GetPickerItem<SKStrokeCap>(strokeCapPicker) // ,
   //             StrokeJoin = GetPickerItem<SKStrokeJoin>(strokeJoinPicker)
            };

            SKPoint[] points = new SKPoint[10];

            for (int i = 0; i < 2; i++)
            {
                float x = (0.1f + 0.8f * i) * info.Width;

                for (int j = 0; j < 5; j++)
                {
                    float y = (0.1f + 0.2f * j) * info.Height;
                    points[2 * j + i] = new SKPoint(x, y);
                }
            }

            canvas.DrawPoints(GetPickerItem<SKPointMode>(pointModePicker), points, paint);
        }

        T GetPickerItem<T>(Picker picker)
        {
            if (picker.SelectedIndex == -1)
            {
                return default(T);
            }

            return (T)Enum.Parse(typeof(T), picker.Items[picker.SelectedIndex]);
        }
    }
}
