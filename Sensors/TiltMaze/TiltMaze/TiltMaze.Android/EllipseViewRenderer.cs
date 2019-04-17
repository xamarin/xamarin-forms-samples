using System.ComponentModel;

using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.FormsBook.Platform.EllipseView), 
                          typeof(Xamarin.FormsBook.Platform.Android.EllipseViewRenderer))]

namespace Xamarin.FormsBook.Platform.Android
{
    public class EllipseViewRenderer : ViewRenderer<EllipseView, EllipseDrawableView>
    {
        double width, height;

        public EllipseViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<EllipseView> args)
        {
            base.OnElementChanged(args);

            if (Control == null)
            {
                SetNativeControl(new EllipseDrawableView(Context));
            }

            if (args.NewElement != null)
            {
                SetColor();
                SetSize();
            }
        }

        protected override void OnElementPropertyChanged(object sender, 
                                                         PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                width = Element.Width;
                SetSize();
            }
            else if (args.PropertyName == VisualElement.HeightProperty.PropertyName)
            {
                height = Element.Height;
                SetSize();
            }
            else if (args.PropertyName == EllipseView.ColorProperty.PropertyName)
            {
                SetColor();
            }
        }

        void SetColor()
        {
           Control.SetColor(Element.Color);
        }

        void SetSize()
        {
           Control.SetSize(width, height);
        }
    }
}