using System;
using Xamarin.Forms;

namespace AnimationSampler
{
    class SpinningTextAnimationPage : ContentPage
    {
        Label label;

        public SpinningTextAnimationPage()
        {
            label = new Label
            {
                Text = "TEXT",
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            this.Content = label;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Apply several "forever" animations.
            label.Animate("RotationZ", (double progress) =>
            {
                label.Rotation = 360 * progress;
            },
            16, 2000, null, null, () => { return true; });

            label.Animate("RotationX", (double progress) =>
            {
                label.RotationX = 360 * progress;
            },
            16, 3000, null, null, () => { return true; });

            label.Animate("RotationY", (double progress) =>
            {
                label.RotationY = 360 * progress;
            },
            16, 5000, null, null, () => { return true; });

            label.Animate("Scale", (double progress) =>
            {
                double reversingProgress = 
                    1 - Math.Abs(2 * progress - 1);
                label.Scale = 1 + 9 * reversingProgress;
            }, 
            16, 7000, null, null, () => { return true; });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            label.AbortAnimation("RotationZ");
            label.AbortAnimation("RotationX");
            label.AbortAnimation("RotationY");
            label.AbortAnimation("Scale");
        }
    }
}
