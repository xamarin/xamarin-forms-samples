using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ButtonDemos
{
	public partial class PressAndReleaseButtonPage : ContentPage
	{
        bool animationInProgress = false;
        Stopwatch stopwatch = new Stopwatch();

		public PressAndReleaseButtonPage ()
		{
			InitializeComponent ();
		}

        void OnButtonPressed(object sender, EventArgs args)
        {
            stopwatch.Start();
            animationInProgress = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(16), () =>
            {
                label.Rotation = 360 * (stopwatch.Elapsed.TotalSeconds % 1);

                return animationInProgress;
            });
        }

        void OnButtonReleased(object sender, EventArgs args)
        {
            animationInProgress = false;
            stopwatch.Stop();
        }
    }
}