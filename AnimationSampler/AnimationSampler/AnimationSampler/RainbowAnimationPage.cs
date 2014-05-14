using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimationSampler
{
    class RainbowAnimationPage : ContentPage
    {
        public RainbowAnimationPage()
        {
            AnimationLoop();
        }

        async void AnimationLoop()
        {
            while (true)
            {
                this.BackgroundColor = Color.FromRgb(1.0, 0, 0);
                await ColorTo(this, Color.FromRgb(1.0, 1.0, 0), 5000);
                await ColorTo(this, Color.FromRgb(0, 1.0, 0), 5000);
                await ColorTo(this, Color.FromRgb(0, 1.0, 1.0), 5000);
                await ColorTo(this, Color.FromRgb(0, 0, 1.0), 5000);
                await ColorTo(this, Color.FromRgb(1.0, 0, 1.0), 5000);
                await ColorTo(this, Color.FromRgb(1.0, 0, 0), 5000);
            }
        }

        Task<bool> ColorTo (VisualElement view, Color color, uint length = 250, Easing easing = null)
        {
            if (easing == null)
                easing = Easing.Linear;

            var tcs = new TaskCompletionSource<bool> ();
            var start = view.BackgroundColor;

            Func<double, Color> computeColor = progress => {
                double r = start.R + (color.R - start.R) * progress;
                double g = start.G + (color.G - start.B) * progress;
                double b = start.B + (color.B - start.B) * progress;
                double a = start.A + (color.A - start.A) * progress;

                return Color.FromRgba(r, g, b, a);
            };

            Animation anima = new Animation (progress => view.BackgroundColor = computeColor(progress), 0, 1, easing);
            anima.Commit(view, "ColorTo", 16, length, 
                                 finished: (f, a) => tcs.SetResult (a));
            return tcs.Task;
        }

    }
}
