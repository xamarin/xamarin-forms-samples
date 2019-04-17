using CoreGraphics;
using UIKit;

namespace Xamarin.FormsBook.Platform.iOS
{
    public class EllipseUIView : UIView
    {
        UIColor color = UIColor.Clear;

        public EllipseUIView()
        {
            BackgroundColor = UIColor.Clear;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            using (CGContext graphics = UIGraphics.GetCurrentContext())
            {
                //Create ellipse geometry based on rect field.
                CGPath path = new CGPath();
                path.AddEllipseInRect(rect);
                path.CloseSubpath();

                //Add geometry to graphics context and draw it.
                color.SetFill();
                graphics.AddPath(path);
                graphics.DrawPath(CGPathDrawingMode.Fill);
            }
        }

        public void SetColor(UIColor color)
        {
            this.color = color;
            SetNeedsDisplay();
        }
    }
}
