using System;
using Xamarin.Forms;

namespace BasicAnimation
{
	public partial class ScaleAnimationPage : ContentPage
	{
		public ScaleAnimationPage ()
		{
			InitializeComponent ();
		}

		void SetIsEnabledButtonState (bool startButtonState, bool cancelButtonState)
		{
			startButton.IsEnabled = startButtonState;
			cancelButton.IsEnabled = cancelButtonState;
		}

		async void OnStartAnimationButtonClicked (object sender, EventArgs e)
		{
			SetIsEnabledButtonState (false, true);

			bool isCancelled = await image.ScaleTo (2, 2000);
			if (!isCancelled) {
				await image.ScaleTo (1, 2000);
			}

			SetIsEnabledButtonState (true, false);
		}

		void OnCancelAnimationButtonClicked (object sender, EventArgs e)
		{
			ViewExtensions.CancelAnimations (image);
			SetIsEnabledButtonState (true, false);
		}
	}
}


//var upAnimation = new Animation (v => image.Scale = v, 1, 2, Easing.SpringIn);
//var rotateAnimation = new Animation (v => image.Rotation = v, 0, 360);
//var downAnimation = new Animation (v => image.Scale = v, 2, 1, Easing.SpringOut);

