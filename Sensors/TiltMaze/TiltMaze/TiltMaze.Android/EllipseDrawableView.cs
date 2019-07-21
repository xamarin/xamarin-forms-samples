using Android.Content;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics;

namespace Xamarin.FormsBook.Platform.Android
{
    public class EllipseDrawableView : View
    {
        ShapeDrawable drawable;

        public EllipseDrawableView(Context context) : base(context)
        {
            drawable = new ShapeDrawable(new OvalShape());
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            drawable.Draw(canvas);
        }

        public void SetColor(Xamarin.Forms.Color color)
        {
            drawable.Paint.SetARGB((int)(255 * color.A), 
                                   (int)(255 * color.R), 
                                   (int)(255 * color.G), 
                                   (int)(255 * color.B));
            Invalidate();
        }

        public void SetSize(double width, double height)
        {
            float pixelsPerDip = Resources.DisplayMetrics.Density;
            drawable.SetBounds(0, 0, (int)(width * pixelsPerDip), 
                                     (int)(height * pixelsPerDip));
            Invalidate();
        }
    }
}