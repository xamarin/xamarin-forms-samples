using System;
using Xamarin.Forms;

namespace AnimationDemo
{
	public class ChildAnimationPageCS : ContentPage
	{
		Image image;
		Button startButton, cancelButton;

		public ChildAnimationPageCS()
		{
			Title = "Child Animations";
			Icon = "csharp.png";

			image = new Image
			{
				Source = ImageSource.FromFile("monkey.png"),
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			startButton = new Button { Text = "Start Animation", VerticalOptions = LayoutOptions.End };
			startButton.Clicked += OnStartAnimationButtonClicked;

			cancelButton = new Button { Text = "Cancel Animation", IsEnabled = false };
			cancelButton.Clicked += OnCancelAnimationButtonClicked;

			Content = new StackLayout
			{
				Margin = new Thickness(0, 20, 0, 0),
				Children = {
					image,
					startButton,
					cancelButton
				}
			};
		}

		void SetIsEnabledButtonState(bool startButtonState, bool cancelButtonState)
		{
			startButton.IsEnabled = startButtonState;
			cancelButton.IsEnabled = cancelButtonState;
		}

		void OnStartAnimationButtonClicked(object sender, EventArgs e)
		{
			SetIsEnabledButtonState(false, true);

			var parentAnimation = new Animation();
			var scaleUpAnimation = new Animation(v => image.Scale = v, 1, 2, Easing.SpringIn);
			var rotateAnimation = new Animation(v => image.Rotation = v, 0, 360);
			var scaleDownAnimation = new Animation(v => image.Scale = v, 2, 1, Easing.SpringOut);

			parentAnimation.Add(0, 0.5, scaleUpAnimation);
			parentAnimation.Add(0, 1, rotateAnimation);
			parentAnimation.Add(0.5, 1, scaleDownAnimation);

			parentAnimation.Commit(this, "ChildAnimations", 16, 4000, null, (v, c) => SetIsEnabledButtonState(true, false));

			//			new Animation {
			//				{ 0, 0.5, new Animation (v => image.Scale = v, 1, 2) },
			//				{ 0, 1, new Animation (v => image.Rotation = v, 0, 360) },
			//				{ 0.5, 1, new Animation (v => image.Scale = v, 2, 1) }
			//			}.Commit (this, "ChildAnimations", 16, 4000, null, (v, c) => SetIsEnabledButtonState (true, false));
		}

		void OnCancelAnimationButtonClicked(object sender, EventArgs e)
		{
			this.AbortAnimation("ChildAnimations");
			SetIsEnabledButtonState(true, false);
		}
	}
}
