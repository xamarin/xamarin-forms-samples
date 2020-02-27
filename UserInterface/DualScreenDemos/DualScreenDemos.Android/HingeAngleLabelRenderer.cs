using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.DualScreen;
using Xamarin.Forms.Platform.Android;
using DualScreenDemos.Droid;
using DualScreenDemos;

[assembly: ExportRenderer(typeof(HingeAngleLabel), typeof(HingeAngleLabelRenderer))]
namespace DualScreenDemos.Droid
{
	public class HingeAngleLabelRenderer : Xamarin.Forms.Platform.Android.FastRenderers.LabelRenderer
	{
		System.Timers.Timer _hingeTimer;
		public HingeAngleLabelRenderer(Context context) : base(context)
		{
		}

		async void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
            if (_hingeTimer == null)
                return;

            _hingeTimer.Stop();
            var hingeAngle = await DualScreenInfo.Current.GetHingeAngleAsync();

            Device.BeginInvokeOnMainThread(() =>
            {
                if (_hingeTimer != null)
                    Element.Text = hingeAngle.ToString();
            });

            if (_hingeTimer != null)
                _hingeTimer.Start();
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (_hingeTimer == null)
			{
				_hingeTimer = new System.Timers.Timer(100);
				_hingeTimer.Elapsed += OnTimerElapsed;
				_hingeTimer.Start();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (_hingeTimer != null)
			{
				_hingeTimer.Elapsed -= OnTimerElapsed;
				_hingeTimer.Stop();
				_hingeTimer = null;
			}

			base.Dispose(disposing);
		}
	}
}