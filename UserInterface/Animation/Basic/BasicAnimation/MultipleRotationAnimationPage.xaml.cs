using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BasicAnimation
{
	public partial class MultipleRotationAnimationPage : ContentPage
	{
		public MultipleRotationAnimationPage ()
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

			// 10 minute animation
			uint duration = 10 * 60 * 1000; 

			await Task.WhenAll (
				image.RotateTo (307 * 360, duration),
				image.RotateXTo (251 * 360, duration),
				image.RotateYTo (199 * 360, duration)
			);

			image.Rotation = 0;
			image.RotationX = 0;
			image.RotationY = 0;

			SetIsEnabledButtonState (true, false);
		}

		void OnCancelAnimationButtonClicked (object sender, EventArgs e)
		{
			ViewExtensions.CancelAnimations (image);
			SetIsEnabledButtonState (true, false);
		}
	}
}

