using System;
using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class SimpleAnimationPage : ContentPage
	{
		public SimpleAnimationPage ()
		{
			InitializeComponent ();
		}

		void SetIsEnabledButtonState (bool startButtonState, bool cancelButtonState)
		{
			startButton.IsEnabled = startButtonState;
			cancelButton.IsEnabled = cancelButtonState;
		}

		void OnStartAnimationButtonClicked (object sender, EventArgs e)
		{
			SetIsEnabledButtonState (false, true);

			var animation = new Animation (v => image.Scale = v, 1, 2);
			animation.Commit (this, "SimpleAnimation", 16, 2000, Easing.Linear, (v, c) => image.Scale = 1, () => true);
		}

		void OnCancelAnimationButtonClicked (object sender, EventArgs e)
		{
			this.AbortAnimation ("SimpleAnimation");
			SetIsEnabledButtonState (true, false);
		}
	}
}
