using System;

using Xamarin.Forms;

namespace SpinPaint
{
    class SquareLayout : Layout<View>
    {
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (Double.IsPositiveInfinity(widthConstraint) &&
                Double.IsPositiveInfinity(heightConstraint))
            {
                throw new ArgumentException("SquareLayout dimensions cannot both be unconstrained.");
            }

            double minDimension = Math.Min(widthConstraint, heightConstraint);
            return new SizeRequest(new Size(minDimension, minDimension));
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            foreach (View child in Children)
            {
                child.Layout(new Rectangle(x, y, width, height));
            }
        }
    }
}
