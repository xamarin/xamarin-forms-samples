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
        // Structure for storing information about the three hands.
        struct HandParams
        {
            public HandParams(double width, double height, double offset) : this()
            {
                Width = width;
                Height = height;
                Offset = offset;
            }

            public double Width { get; }   // fraction of radius
            public double Height { get; }  // ditto
            public double Offset { get; }  // relative to center pivot
        }

        static readonly HandParams secondParams = new HandParams(0.02, 1.1, 0.85);
        static readonly HandParams minuteParams = new HandParams(0.05, 0.8, 0.9);
        static readonly HandParams hourParams = new HandParams(0.125, 0.65, 0.9);

        private static ClockedBoxView NewClockedBoxView(int index) =>
                         new ClockedBoxView(index){ Color = Color.Accent };

        private static BoxView NewBoxView() => new BoxView { Color = Color.Accent };

        ClockedBoxView[] tickMarks = Repeat(NewClockedBoxView, 60).ToArray();
        BoxView secondHand = NewBoxView(),
                minuteHand = NewBoxView(),
                hourHand = NewBoxView();

        public BoxViewClockPage()
        {
            var hands = new BoxView[] { hourHand, minuteHand, secondHand };
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            absoluteLayout.Children.AddRange(tickMarks).AddRange(hands);
            Content = absoluteLayout;

            // Attach a couple event handlers.
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
            SizeChanged += OnPageSizeChanged;
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            var radius = tickMarks.First().Radius;
            var center = tickMarks.First().Center;

            foreach (var tickMark in tickMarks)
            {
                AbsoluteLayout.SetLayoutBounds(tickMark, tickMark.GetRectangle());
                tickMark.AnchorX = 0.51;        // Anchor settings necessary for Android
                tickMark.AnchorY = 0.51;
                tickMark.UpdateRotation();
            }

            // Function for positioning and sizing hands.
            Action<BoxView, HandParams> Layout = (boxView, handParams) =>
            {
                double width = handParams.Width * radius;
                double height = handParams.Height * radius;
                double offset = handParams.Offset;

                AbsoluteLayout.SetLayoutBounds(boxView,
                    new Rectangle(center.X - 0.5 * width,
                                  center.Y - offset * height,
                                  width, height));

                boxView.AnchorX = 0.51;
                boxView.AnchorY = handParams.Offset;
            };

            Layout(secondHand, secondParams);
            Layout(minuteHand, minuteParams);
            Layout(hourHand, hourParams);
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
