using EffectsDemo.UWP;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.UWP
{
    public class LabelShadowEffect : PlatformEffect
    {

        bool shadowAdded = false;

        protected override void OnAttached()
        {
            try
            {
                if (!shadowAdded)
                {
                    var textBlock = Control as Windows.UI.Xaml.Controls.TextBlock;

                    var shadowLabel = new Label();
                    shadowLabel.Text = textBlock.Text;
                    shadowLabel.FontAttributes = FontAttributes.Bold;
                    shadowLabel.HorizontalOptions = LayoutOptions.Center;
                    shadowLabel.VerticalOptions = LayoutOptions.CenterAndExpand;
                    shadowLabel.TextColor = Color.Red;
                    shadowLabel.TranslationX = 5;
                    shadowLabel.TranslationY = 5;

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
    }
}
