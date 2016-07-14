using System;
using Xamarin.Forms;

namespace BasicAnimation
{
	public partial class RotateAnimationWithAnchorsPage : ContentPage
	{
		public RotateAnimationWithAnchorsPage ()
		{
			InitializeComponent ();
		}

		void OnImageSizeChanged (object sender, EventArgs e)
		{
			var center = new Point (absoluteLayout.Width / 2, absoluteLayout.Height / 2);
			AbsoluteLayout.SetLayoutBounds (image, new Rectangle (center.X - image.Width / 2, center.Y - image.Height / 2, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
		}

		void SetIsEnabledButtonState (bool startButtonState, bool cancelButtonState)
		{
			startButton.IsEnabled = startButtonState;
			cancelButton.IsEnabled = cancelButtonState;
		}

		async void OnStartAnimationButtonClicked (object sender, EventArgs e)
		{
			SetIsEnabledButtonState (false, true);

			image.AnchorY = (Math.Min (absoluteLayout.Width, absoluteLayout.Height) / 2) / image.Height;
			await image.RotateTo (360, 2000);
			image.Rotation = 0;

			SetIsEnabledButtonState (true, false);
		}

		void OnCancelAnimationButtonClicked (object sender, EventArgs e)
		{
			ViewExtensions.CancelAnimations (image);
			SetIsEnabledButtonState (true, false);
		}
	}
}

