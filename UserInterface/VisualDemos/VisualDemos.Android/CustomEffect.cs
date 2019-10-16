using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(VisualDemos.Droid.CustomEffect), nameof(VisualDemos.Droid.CustomEffect))]
namespace VisualDemos.Droid
{
    public class CustomEffect : PlatformEffect
    {
        Random rand = new Random();
        protected override void OnAttached()
        {
            try
            {
                Control.Rotation = 50;
            }
            catch (Exception ex)
            {
                Console.Write($"Failed to set property: {ex.Message}");
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
