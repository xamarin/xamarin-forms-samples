using System;
using Xamarin.Forms;

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

            public double Width { private set; get; }   // fraction of radius
            public double Height { private set; get; }  // ditto
            public double Offset { private set; get; }  // relative to center pivot
        }

        static readonly HandParams secondParams = new HandParams(0.02, 1.1, 0.85);
        static readonly HandParams minuteParams = new HandParams(0.05, 0.8, 0.9);
        static readonly HandParams hourParams = new HandParams(0.125, 0.65, 0.9);

        BoxView[] tickMarks = new BoxView[60];
        BoxView secondHand, minuteHand, hourHand;

        public BoxViewClockPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();

            // Create the tick marks (to be sized and positioned later)
            for (int i = 0; i < tickMarks.Length; i++)
            {
                tickMarks[i] = new BoxView
                {
                    Color = Color.Accent
                };
                absoluteLayout.Children.Add(tickMarks[i]);
            }

            // Create the three hands.
            absoluteLayout.Children.Add(hourHand = 
                new BoxView
                {
                    Color = Color.Accent
                });
            absoluteLayout.Children.Add(minuteHand = 
                new BoxView
                {
                    Color = Color.Accent
                });
            absoluteLayout.Children.Add(secondHand = 
                new BoxView
                {
                    Color = Color.Accent
                });

            Content = absoluteLayout;

            // Attach a couple event handlers.
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
            SizeChanged += OnPageSizeChanged;
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            // Size and position the 12 tick marks.
            Point center = new Point(this.Width / 2, this.Height / 2);
            double radius = 0.45 * Math.Min(this.Width, this.Height);

            for (int i = 0; i < tickMarks.Length; i++)
            {
                double size = radius / (i % 5 == 0 ? 15 : 30);
                double radians = i * 2 * Math.PI / tickMarks.Length;
                double x = center.X + radius * Math.Sin(radians) - size / 2;
                double y = center.Y - radius * Math.Cos(radians) - size / 2;
                AbsoluteLayout.SetLayoutBounds(tickMarks[i], new Rectangle(x, y, size, size));

                tickMarks[i].AnchorX = 0.51;        // Anchor settings necessary for Android
                tickMarks[i].AnchorY = 0.51;
                tickMarks[i].Rotation = 180 * radians / Math.PI;
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
