using System;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using EffectsDemo.UWP;

[assembly:ResolutionGroupName("MyCompany")]
[assembly:ExportEffect(typeof(BackgroundColorEffect), "BackgroundColorEffect")]
namespace EffectsDemo.UWP
{
    public class BackgroundColorEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                (Control as Windows.UI.Xaml.Controls.Control).Background = new SolidColorBrush(Colors.Cyan);
                (Control as FormsTextBox).BackgroundFocusBrush = new SolidColorBrush(Colors.Cyan);
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
