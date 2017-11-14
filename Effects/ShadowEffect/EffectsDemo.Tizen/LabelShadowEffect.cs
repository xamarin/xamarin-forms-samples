using EffectsDemo.Tizen;
using System;
using System.Linq;
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
                var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);

                if (effect != null)
                {
                    ApplyShadowEffect(effect);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not set the shadow effect on the native control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        private static string GetColor(ShadowEffect effect)
        {
            var c = effect.Color.ToNative();
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", c.R, c.G, c.B, c.A);
        }

        private static string GetLabelDirection(ShadowEffect effect)
        {
            if (effect.DistanceX < 0.0 && effect.DistanceY < 0.0)
            {
                return "top_left";
            }
            else if (effect.DistanceX == 0.0 && effect.DistanceY < 0.0)
            {
                return "top";
            }
            else if (effect.DistanceX > 0.0 && effect.DistanceY < 0.0)
            {
                return "top_right";
            }
            else if (effect.DistanceX > 0.0 && effect.DistanceY == 0.0)
            {
                return "right";
            }
            else if (effect.DistanceX > 0.0 && effect.DistanceY > 0.0)
            {
                return "bottom_right";
            }
            else if (effect.DistanceX == 0.0 && effect.DistanceY > 0.0)
            {
                return "bottom";
            }
            else if (effect.DistanceX < 0.0 && effect.DistanceY > 0.0)
            {
                return "bottom_left";
            }
            else if (effect.DistanceX < 0.0 && effect.DistanceY == 0.0)
            {
                return "left";
            }
            else
            {
                // platform default
                return "";
            }
        }

        private void ApplyShadowEffect(ShadowEffect effect)
        {
            var textblock = (Control as ElmSharp.Label).EdjeObject["elm.text"];
            var sb = new StringBuilder(textblock.TextStyle);

            sb.Remove(sb.Length - 1, 1);  // remove '
            sb.AppendFormat(" style=far_soft_shadow,{0} shadow_color={1}'", GetLabelDirection(effect), GetColor(effect));  // add shadow style & color

            textblock.TextStyle = sb.ToString();
        }
    }
}
