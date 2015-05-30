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

        ClockedBoxView[] TickMarks = Repeat(NewClockedBoxView, 60).ToArray();

        HandedBoxView secondHand = HandedBoxView.GetHourHand(Color.Accent),
                      minuteHand = HandedBoxView.GetMinuteHand(Color.Accent),
                      hourHand = HandedBoxView.GetHourHand(Color.Accent);

        HandedBoxView[] Hands => new HandedBoxView[] { hourHand, minuteHand, secondHand };
        IList<IUpdateLayoutable> AllBoxViews => TickMarks.Cast<IUpdateLayoutable>().Concat(Hands).ToList();

        public BoxViewClockPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            absoluteLayout.Children.AddRange(AllBoxViews.Cast<BoxView>());
            Content = absoluteLayout;
            // Attach a couple event handlers.
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
            SizeChanged += OnPageSizeChanged;
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            foreach (var tickMark in AllBoxViews)
            {
                tickMark.UpdateLayout(this);
            }
        }

        bool OnTimerTick()
        {
            // Set rotation angles for hour and minute hands.
            DateTime dateTime = DateTime.Now;
            hourHand.UpdateRotation(dateTime);
            minuteHand.UpdateRotation(dateTime);
            secondHand.UpdateRotation(dateTime);
            return true;
        }
    }
}
