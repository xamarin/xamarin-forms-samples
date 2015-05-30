using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using static BoxViewClock.Helpers.IEnumerableHelpers;
using BoxViewClock.Views;

namespace BoxViewClock
{
    class BoxViewClockPage : ContentPage
    {
        private static ClockedBoxView NewClockedBoxView(int index) =>
                         new ClockedBoxView(index){ Color = Color.Accent };

        ClockedBoxView[] TickMarks = Repeat(NewClockedBoxView, 60).ToArray();

        HandedBoxView secondHand = HandedBoxView.GetSecondHand(Color.Accent),
                      minuteHand = HandedBoxView.GetMinuteHand(Color.Accent),
                      hourHand = HandedBoxView.GetHourHand(Color.Accent);

        HandedBoxView[] Hands => new HandedBoxView[] { hourHand, minuteHand, secondHand };
        IList<BaseClockedView> AllBoxViews => TickMarks.Cast<BaseClockedView>().Concat(Hands).ToList();

        public BoxViewClockPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            absoluteLayout.Children.AddRange(AllBoxViews);
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
            foreach(var hand in Hands)
            {
                hand.UpdateRotation(DateTime.Now);
            }
            return true;
        }
    }
}
