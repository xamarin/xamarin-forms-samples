using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using MyCompany.Forms.PlatformConfiguration.Tizen;
using ShadowPlatformSpecific.Tizen;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace ShadowPlatformSpecific.Tizen
{
    public class LabelShadowEffect : PlatformEffect
    {
        private bool shadowAdded = false;

        protected override void OnAttached()
        {
            UpdateShadow();
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == Shadow.IsShadowedProperty.PropertyName)
            {
                UpdateShadow();
            }
        }

        private static string GetColor()
        {
            var c = Color.Gray.ToNative();
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", c.R, c.G, c.B, c.A);
        }


        void UpdateShadow()
        {
            try
            {
                if (((Label)Element).OnThisPlatform().IsShadowed() && !shadowAdded)
                {
                    var textblock = (Control as ElmSharp.Label).EdjeObject["elm.text"];
                    var sb = new StringBuilder(textblock.TextStyle);

                    sb.Remove(sb.Length - 1, 1);  // remove '
                    sb.AppendFormat(" style=far_soft_shadow shadow_color={0}'", GetColor());  // add shadow style & color

                    textblock.TextStyle = sb.ToString();
                    shadowAdded = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }
    }
}