using System;
using System.Text;
using EffectsDemo.Tizen;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.Tizen
{
    public class LabelShadowEffect : PlatformEffect
    {
        private const string ShadowColor = "#0000FF";

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

        private void ApplyShadowEffect()
        {
            var textblock = (Control as ElmSharp.Label).EdjeObject["elm.text"];
            var sb = new StringBuilder(textblock.TextStyle);

            sb.Remove(sb.Length - 1, 1);  // remove '
            sb.AppendFormat(" style=far_soft_shadow shadow_color={0}'", ShadowColor);  // add shadow style & color

            textblock.TextStyle = sb.ToString();
        }
    }
}
