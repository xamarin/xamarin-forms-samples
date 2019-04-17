using UIKit;
using VisualDemos;
using VisualDemos.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer), new[] { typeof(CustomVisual) })]
namespace VisualDemos.iOS
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Cleanup
            }

            if (e.NewElement != null)
            {
                Control.TitleShadowOffset = new CoreGraphics.CGSize(1, 1);
                Control.SetTitleShadowColor(Color.Black.ToUIColor(), UIKit.UIControlState.Normal);
            }
        }
    }
}
