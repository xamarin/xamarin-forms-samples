using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using static BoxViewClock.Helpers.IEnumerableHelpers;
using static System.Math;
using BoxViewClock.Views;

namespace BoxViewClock
{
    class BoxViewClockPage : ContentPage
    {
        private static ClockedBoxView NewClockedBoxView(int index) =>
                         new ClockedBoxView(index){ Color = Color.Accent };

        private static HandedBoxView NewHandedBoxView(double width, double height, double offset) =>
                           new HandedBoxView(width, height, offset) { Color = Color.Accent };

        ClockedBoxView[] tickMarks = Repeat(NewClockedBoxView, 60).ToArray();

        HandedBoxView secondHand = NewHandedBoxView(0.02, 1.1, .85),
                      minuteHand = NewHandedBoxView(0.05, 0.8, .9),
                      hourHand = NewHandedBoxView(0.125, 0.65, .9);

        HandedBoxView[] Hands => new HandedBoxView[] { hourHand, minuteHand, secondHand };

        public BoxViewClockPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            absoluteLayout.Children.AddRange(tickMarks).AddRange(Hands);
            Content = absoluteLayout;

            // Attach a couple event handlers.
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
            SizeChanged += OnPageSizeChanged;
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {

            foreach (var tickMark in tickMarks)
            {
                AbsoluteLayout.SetLayoutBounds(tickMark, tickMark.GetRectangle(this));
                tickMark.AnchorX = 0.51;        // Anchor settings necessary for Android
                tickMark.AnchorY = 0.51;
                tickMark.UpdateRotation();
            }
            foreach(var hand in Hands)
            {
                hand.UpdateLayout(this);
            }
        }

        bool OnTimerTick()
        {
            // Set rotation angles for hour and minute hands.
            DateTime dateTime = DateTime.Now;
            hourHand.Rotation = 30 * (dateTime.Hour % 12) + 0.5 * dateTime.Minute;
            minuteHand.Rotation = 6 * dateTime.Minute + 0.1 * dateTime.Second;

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
            secondHand.Rotation = 6 * (dateTime.Second + t);
            return true;
        }
    }
}
