using System;
using Xamarin.Forms;

namespace BoxViewClock.Views
{
    public class HandedBoxView : BaseClockedView
    {
        private enum HandType
        {
            Second = 1,
            Minute = 2,
            Hour = 3
        }

        public static HandedBoxView GetHourHand(Color color) => new HandedBoxView(0.125, 0.65, .9, HandType.Hour) { Color = color};
        public static HandedBoxView GetMinuteHand(Color color) => new HandedBoxView(0.05, 0.8, .9, HandType.Minute) {Color = color};
        public static HandedBoxView GetSecondHand(Color color) => new HandedBoxView(0.02, 1.1, .85, HandType.Second) {Color = color};

        private double HandWidth { get; }   // fraction of radius
        private double HandHeight { get; }  // ditto
        private double Offset { get; }  // relative to center pivot
        private HandType MyHandType { get; }

        private HandedBoxView(
            double handWidth,
            double handHeight,
            double offset,
            HandType handType):base()
        {
            HandWidth = handWidth;
            HandHeight = handHeight;
            Offset = offset;
            MyHandType = handType;
        }

        public Rectangle GetRectangle (Page page)
        {
            Point center = page.Center();
            double radius = page.Radius();
            double width = HandWidth * radius;
            double height = HandHeight * radius;
            double offset = Offset;
            return new Rectangle(
                center.X - 0.5 * width,
                center.Y - offset * height,
                width,
                height
            );
        }

        public override void UpdateLayout(Page page)
        {
            AbsoluteLayout.SetLayoutBounds(this, GetRectangle(page));
            AnchorX = 0.51;
            AnchorY = Offset;
        }

        private double GetRotation (DateTime dateTime)
        {
            switch (MyHandType)
            {
                case HandType.Hour: return 30 * (dateTime.Hour % 12) + 0.5 * dateTime.Minute;
                case HandType.Minute: return 6 * dateTime.Minute + 0.1 * dateTime.Second;
                case HandType.Second:
                    // Do an animation for the second hand.
                    double t = dateTime.Millisecond / 1000.0;
                    if (t < 0.5)
                    {
                        t = 0.5 * Easing.SpringIn.Ease(t / 0.5);
                    }
                    else
                    {
                        t = 0.5 * (1 + Easing.SpringOut.Ease((t - 0.5) / 0.5));
                    }
                    return 6 * (dateTime.Second + t);
                default:
                    throw new Exception("Hands has invalid type");
            }
        }

        public void UpdateRotation(DateTime time)
        {
            Rotation = GetRotation(time);
        }
    }

}
