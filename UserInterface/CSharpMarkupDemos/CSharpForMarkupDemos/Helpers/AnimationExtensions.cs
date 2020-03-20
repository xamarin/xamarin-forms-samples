using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CSharpForMarkupDemos.Helpers
{
    public static class AnimationExtensions
    {
        public static void StaggerIn(this IEnumerable<View> children, float translation, double delay)
        {
            int i = 0;
            foreach (View view in children)
            {
                view.Opacity = 0;
                view.TranslationY = translation;

                Task.Delay(TimeSpan.FromSeconds(i++ * delay))
                    .ContinueWith(_ =>
                    {
                        view.FadeTo(1);
                        view.TranslateTo(0, 0, easing: Easing.CubicOut);
                    });
            }
        }
    }
}
