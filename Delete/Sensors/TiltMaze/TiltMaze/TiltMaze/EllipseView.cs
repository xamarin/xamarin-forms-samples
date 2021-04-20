using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Platform
{
    public class EllipseView : View
    {
        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(
                "Color",
                typeof(Color),
                typeof(EllipseView),
                Color.Default);

        public Color Color
        {
            set { SetValue(ColorProperty, value); }
            get { return (Color)GetValue(ColorProperty); }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest(new Size(40, 40));
        }
    }
}
