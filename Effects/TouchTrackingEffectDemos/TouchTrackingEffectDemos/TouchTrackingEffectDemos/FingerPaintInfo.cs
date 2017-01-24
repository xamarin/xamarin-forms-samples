using Xamarin.Forms;

namespace TouchTrackingEffectDemos
{
    class FingerPaintInfo
    {
        public FingerPaintInfo()
        {
        }

        public Point PreviousPoint { set; get; }

        public Color StrokeColor { set; get; }

        public double StrokeThickness { set; get; }
    }
}
