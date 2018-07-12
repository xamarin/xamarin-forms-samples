using EffectsDemo.Tizen;
using System;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.Tizen
{
    public class LabelShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                ApplyShadowEffect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not set the shadow effect on the native control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ShadowEffect.RadiusProperty.PropertyName ||
                args.PropertyName == ShadowEffect.ColorProperty.PropertyName ||
                args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
                args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName)
            {
                ApplyShadowEffect();
            }
        }

        private string GetColor()
        {
            var c = ShadowEffect.GetColor(Element).ToNative();
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", c.R, c.G, c.B, c.A);
        }

        private string GetLabelDirection()
        {
            var distanceX = ShadowEffect.GetDistanceX(Element);
            var distanceY = ShadowEffect.GetDistanceY(Element);

            if (distanceX < 0.0 && distanceY < 0.0)
            {
                return "top_left";
            }
            else if (distanceX == 0.0 && distanceY < 0.0)
            {
                return "top";
            }
            else if (distanceX > 0.0 && distanceY < 0.0)
            {
                return "top_right";
            }
            else if (distanceX > 0.0 && distanceY == 0.0)
            {
                return "right";
            }
            else if (distanceX > 0.0 && distanceY > 0.0)
            {
                return "bottom_right";
            }
            else if (distanceX == 0.0 && distanceY > 0.0)
            {
                return "bottom";
            }
            else if (distanceX < 0.0 && distanceY > 0.0)
            {
                return "bottom_left";
            }
            else if (distanceX < 0.0 && distanceY == 0.0)
            {
                return "left";
            }
            else
            {
                // platform default
                return "";
            }
        }

        private void ApplyShadowEffect()
        {
            var textblock = (Control as ElmSharp.Label).EdjeObject["elm.text"];
            var sb = new StringBuilder(textblock.TextStyle);

            sb.Remove(sb.Length - 1, 1);  // remove '
            sb.AppendFormat(" style=far_soft_shadow,{0} shadow_color={1}'", GetLabelDirection(), GetColor());  // add shadow style & color

            textblock.TextStyle = sb.ToString();
        }
    }
}
