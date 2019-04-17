using System.ComponentModel;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.FormsBook.Platform.EllipseView), 
                          typeof(Xamarin.FormsBook.Platform.iOS.EllipseViewRenderer))]

namespace Xamarin.FormsBook.Platform.iOS
{
    public class EllipseViewRenderer : ViewRenderer<EllipseView, EllipseUIView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<EllipseView> args)
        {
            base.OnElementChanged(args);

            if (Control == null)
            {
                SetNativeControl(new EllipseUIView());
            }

            if (args.NewElement != null)
            {
                SetColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, 
                                                         PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == EllipseView.ColorProperty.PropertyName)
            {
                SetColor();
            }
        }

        void SetColor()
        {
            if (Element.Color != Color.Default)
            {
                Control.SetColor(Element.Color.ToUIColor());
            }
            else
            {
                Control.SetColor(UIColor.Clear);
            }
        }
    }
}
