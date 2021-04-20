using Android.Graphics;
using Android.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Rect = Android.Graphics.Rect;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(VisualDemos.Droid.RoundEffect), nameof(VisualDemos.Droid.RoundEffect))]
namespace VisualDemos.Droid
{
    public class RoundEffect : PlatformEffect
    {
        ViewOutlineProvider originalProvider;

        protected override void OnAttached()
        {
            try
            {
                originalProvider = Control.OutlineProvider;
                Control.OutlineProvider = new CornerRadiusOutlineProvider(Element);
                Control.ClipToOutline = true;
            }
            catch (Exception ex)
            {
                Console.Write($"Failed to set property: {ex.Message}");
            }
        }

        protected override void OnDetached()
        {
            Control.OutlineProvider = originalProvider;
            Control.ClipToOutline = false;
        }

        class CornerRadiusOutlineProvider : ViewOutlineProvider
        {
            Element element;

            public CornerRadiusOutlineProvider(Element formsElement)
            {
                element = formsElement;
            }

            public override void GetOutline(Android.Views.View view, Outline outline)
            {
                float scale = view.Resources.DisplayMetrics.Density;
                double width = (double)element.GetValue(VisualElement.WidthProperty) * scale;
                double height = (double)element.GetValue(VisualElement.HeightProperty) * scale;
                float minDimension = (float)Math.Min(height, width);
                float radius = minDimension / 2f;
                Rect rect = new Rect(0, 0, (int)width, (int)height);
                outline.SetRoundRect(rect, radius);
            }
        }
    }
}
