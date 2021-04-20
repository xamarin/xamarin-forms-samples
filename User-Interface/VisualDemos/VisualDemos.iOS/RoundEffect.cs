using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(VisualDemos.iOS.RoundEffect), nameof(VisualDemos.iOS.RoundEffect))]
namespace VisualDemos.iOS
{
    public class RoundEffect : PlatformEffect
    {
        nfloat originalRadius;

        protected override void OnAttached()
        {
            if (Control != null)
            {
                originalRadius = Control.Layer.CornerRadius;
                Control.ClipsToBounds = true;
                Control.Layer.CornerRadius = CalculateRadius();
            }
        }

        protected override void OnDetached()
        {
            if (Control != null)
            {
                if (Control.Layer != null)
                {
                    Control.Layer.CornerRadius = originalRadius;
                }
                Control.ClipsToBounds = false;
            }
        }

        float CalculateRadius()
        {
            double width = (double)Element.GetValue(VisualElement.WidthRequestProperty);
            double height = (double)Element.GetValue(VisualElement.HeightRequestProperty);
            float minDimension = (float)Math.Min(height, width);
            float radius = minDimension / 2f;

            return radius;
        }
    }
}
