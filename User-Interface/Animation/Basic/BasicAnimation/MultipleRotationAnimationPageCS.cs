using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BasicAnimation
{
	public class MultipleRotationAnimationPageCS : ContentPage
	{
		Image image;
		Button startButton, cancelButton;

		public MultipleRotationAnimationPageCS ()
		{
			Title = "Multiple Rotation Animation";

			image = new Image { Source = ImageSource.FromFile ("monkey.png"), VerticalOptions = LayoutOptions.CenterAndExpand };
			startButton = new Button { Text = "Start Animation", VerticalOptions = LayoutOptions.End };
			cancelButton = new Button { Text = "Cancel Animation", IsEnabled = false };

			startButton.Clicked += OnStartAnimationButtonClicked;
			cancelButton.Clicked += OnCancelAnimationButtonClicked;

			Content = new StackLayout { 
				Margin = new Thickness (0, 20, 0, 0),
				Children = {
					image,
					startButton,
					cancelButton
				}
			};
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


