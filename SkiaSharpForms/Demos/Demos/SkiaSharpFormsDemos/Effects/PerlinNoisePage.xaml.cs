using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
	public partial class PerlinNoisePage : ContentPage
	{
		public PerlinNoisePage ()
		{
			InitializeComponent ();
		}

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnStepperValueChanged(object sender, ValueChangedEventArgs args)
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

            canvas.Clear();

            // Get values from sliders
            float baseFreqX = (float)baseFrequencyXSlider.Value;
            float baseFreqY = (float)baseFrequencyYSlider.Value;
            int numOctaves = (int)octavesStepper.Value;
            bool useTiles = tileSwitch.IsToggled;

            using (SKPaint paint = new SKPaint())
            {
                SKShader fractalNoiseShader = null;
                SKShader turbulenceShader = null;
                SKPointI tileSize = new SKPointI(100, 100);

                if (useTiles)
                {
                    fractalNoiseShader =
                        SKShader.CreatePerlinNoiseFractalNoise(baseFreqX,
                                                               baseFreqY,
                                                               numOctaves,
                                                               0,
                                                               tileSize);

                    turbulenceShader = 
                        SKShader.CreatePerlinNoiseTurbulence(baseFreqX,
                                                             baseFreqY,
                                                             numOctaves,
                                                             0,
                                                             tileSize);
                }
                else
                {
                    fractalNoiseShader =
                        SKShader.CreatePerlinNoiseFractalNoise(baseFreqX,
                                                               baseFreqY,
                                                               numOctaves,
                                                               0);

                    turbulenceShader =
                        SKShader.CreatePerlinNoiseTurbulence(baseFreqX,
                                                             baseFreqY,
                                                             numOctaves,
                                                             0);
                }

                SKShader fractalShaderWithBackground =
                    SKShader.CreateCompose(SKShader.CreateColor(SKColors.Blue),
                                           fractalNoiseShader);

                SKShader turbulenceShaderWithBackground =
                    SKShader.CreateCompose(SKShader.CreateColor(SKColors.Blue),
                                           turbulenceShader);

                // Display fractal noise
                paint.Shader = fractalNoiseShader;
                SKRect rect = new SKRect(0, 0, info.Width / 2, info.Height / 2);
                canvas.DrawRect(rect, paint);

                paint.Shader = fractalShaderWithBackground;
                rect = new SKRect(info.Width / 2, 0, info.Width, info.Height / 2);
                canvas.DrawRect(rect, paint);

                // Display turbulence
                paint.Shader = turbulenceShader;
                rect = new SKRect(0, info.Height / 2, info.Width / 2, info.Height);
                canvas.DrawRect(rect, paint);

                paint.Shader = turbulenceShaderWithBackground;
                rect = new SKRect(info.Width / 2, info.Height / 2, info.Width, info.Height);
                canvas.DrawRect(rect, paint);
            }
        }
    }
}