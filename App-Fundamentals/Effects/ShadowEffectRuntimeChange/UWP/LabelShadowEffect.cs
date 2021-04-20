using EffectsDemo.UWP;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName ("MyCompany")]
[assembly: ExportEffect (typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.UWP
{
    public class LabelShadowEffect : PlatformEffect
    {
        Label shadowLabel;
        bool shadowAdded = false;

        protected override void OnAttached()
        {
            try
            {
                if (!shadowAdded)
                {
                    var textBlock = Control as Windows.UI.Xaml.Controls.TextBlock;

                    shadowLabel = new Label();
                    shadowLabel.Text = textBlock.Text;
                    shadowLabel.FontAttributes = FontAttributes.Bold;
                    shadowLabel.HorizontalOptions = LayoutOptions.Center;
                    shadowLabel.VerticalOptions = LayoutOptions.CenterAndExpand;

                    UpdateColor();
                    UpdateOffset();

                    ((Grid)Element.Parent).Children.Insert(0, shadowLabel);
                    shadowAdded = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
            else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
                args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName)
            {
                UpdateOffset();
            }

        }

        void UpdateColor()
        {
            shadowLabel.TextColor = ShadowEffect.GetColor(Element);
        }

        void UpdateOffset()
        {
            shadowLabel.TranslationX = ShadowEffect.GetDistanceX(Element);
            shadowLabel.TranslationY = ShadowEffect.GetDistanceY(Element);
        }
    }
}
