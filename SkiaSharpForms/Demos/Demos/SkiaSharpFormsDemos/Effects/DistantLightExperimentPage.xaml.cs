using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
	public partial class DistantLightExperimentPage : InteractivePage
	{
        const string TEXT = "Distant Lit";

        public DistantLightExperimentPage ()
		{
            touchPoints = new TouchPoint[1];

            touchPoints[0] = new TouchPoint
            {
                Center = new SKPoint(200, 200)
            };

            InitializeComponent ();
            baseCanvasView = canvasView;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            // Base the background color on backgroundSwitch
            canvas.Clear(backgroundSwitch.IsToggled ? SKColors.Black : new SKColor());

            // Construct direction
            SKPoint3 direction = new SKPoint3(touchPoints[0].Center.X,
                                              touchPoints[0].Center.Y,
                                              (float)zSlider.Value);

            // Get other slider values
            float surfaceHeight = (float)heightSlider.Value;
            float lightConstant = (float)constantSlider.Value;
            float shininess = (float)shininessSlider.Value;

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;
                paint.TextSize = info.Width / (TEXT.Length / 2f);
                
                if (!specularSwitch.IsToggled)
                {
                    paint.ImageFilter =
                        /*
                                                SKImageFilter.CreateDistantLitDiffuse(direction,
                                                                                      SKColors.White,
                                                                                      surfaceHeight, 
                                                                                      lightConstant);
                        */

                        SKImageFilter.CreatePointLitDiffuse(direction,      // actually location
                                                            SKColors.White,
                                                            surfaceHeight,      // actually scale
                                                            lightConstant);

                }
                else
                {
                    paint.ImageFilter =
                        /*

                                                SKImageFilter.CreateDistantLitSpecular(direction,
                                                                                       SKColors.White,
                                                                                       surfaceHeight, 
                                                                                       lightConstant, 
                                                                                       shininess);
                        */


                        SKImageFilter.CreatePointLitSpecular(direction,
                                                             SKColors.White,
                                                             surfaceHeight,
                                                             lightConstant,
                                                             shininess);


                }

                // Center the text in the canvas
                SKRect textBounds = new SKRect();
                paint.MeasureText(TEXT, ref textBounds);

                float xText = info.Width / 2 - textBounds.MidX;
                float yText = info.Height / 2 - textBounds.MidY;

                canvas.DrawText(TEXT, xText, yText, paint);
            }

            // Draw the touch point
            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Red;
                paint.StrokeWidth = 3;

                canvas.DrawCircle(touchPoints[0].Center, touchPoints[0].Radius, paint);
            }
        }

    }
}