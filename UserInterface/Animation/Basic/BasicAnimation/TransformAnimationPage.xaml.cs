using System;
using Xamarin.Forms;

namespace BasicAnimation
{
	public partial class TransformAnimationPage : ContentPage
	{
		public TransformAnimationPage ()
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

			bool isCancelled = await image.TranslateTo (-100, 0, 1000);
			if (!isCancelled) {				
				isCancelled = await image.TranslateTo (-100, -100, 1000);
			}
			if (!isCancelled) {		
				isCancelled = await image.TranslateTo (100, 100, 2000);
			}
			if (!isCancelled) {		
				isCancelled = await image.TranslateTo (0, 100, 1000);
			}
			if (!isCancelled) {		
				isCancelled = await image.TranslateTo (0, 0, 1000);
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

