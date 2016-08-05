using System;
using Xamarin.Forms;

namespace AnimationDemo
{
	public class SimpleAnimationPageCS : ContentPage
	{
		Image image;
		Button startButton, cancelButton;

		public SimpleAnimationPageCS ()
		{
			Title = "Simple Animation";
			Icon = "csharp.png";

			image = new Image {
				Source = ImageSource.FromFile ("monkey.png"),
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			startButton = new Button { Text = "Start Animation", VerticalOptions = LayoutOptions.End };
			startButton.Clicked += OnStartAnimationButtonClicked;

			cancelButton = new Button { Text = "Cancel Animation", IsEnabled = false };
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
