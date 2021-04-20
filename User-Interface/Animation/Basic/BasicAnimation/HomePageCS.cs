using System;
using Xamarin.Forms;

namespace BasicAnimation
{
	public class HomePageCS : ContentPage
	{
		public HomePageCS ()
		{
			var rotateButton = new Button { Text = "Rotate Animation" };
			rotateButton.Clicked += OnRotateAnimationButtonClicked;
			var relativeRotateButton = new Button { Text = "Relative Rotate Animation" };
			relativeRotateButton.Clicked += OnRelativeRotateAnimationButtonClicked;
			var rotateAnchorButton = new Button { Text = "Rotate Animation with Anchors" };
			rotateAnchorButton.Clicked += OnRotateAnimationWithAnchorsButtonClicked;
			var multipleRotateButton = new Button { Text = "Multiple Rotations" };
			multipleRotateButton.Clicked += OnMultipleRotationAnimationButtonClicked;
			var scaleButton = new Button { Text = "Scale Animation" };
			scaleButton.Clicked += OnScaleAnimationButtonClicked;
			var relativeScaleButton = new Button { Text = "Relative Scale Animation" };
			relativeScaleButton.Clicked += OnRelativeScaleAnimationButtonClicked;
			var transformButton = new Button { Text = "Transform Animation" };
			transformButton.Clicked += OnTransformAnimationButtonClicked;
			var fadeButton = new Button { Text = "Fade Animation" };
			fadeButton.Clicked += OnFadeAnimationButtonClicked;

			Title = "Basic Animation Demo";
			Content = new StackLayout { 
				Margin = new Thickness (0, 20, 0, 0),
				Children = {
					rotateButton,
					relativeRotateButton,
					rotateAnchorButton,
					multipleRotateButton,
					scaleButton,
					relativeScaleButton,
					transformButton,
					fadeButton
				}
			};
		}

		async void OnRotateAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new RotateAnimationPageCS ());
		}

		async void OnRelativeRotateAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new RelativeRotationPageCS ());
		}

		async void OnRotateAnimationWithAnchorsButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new RotateAnimationWithAnchorsPageCS ());
		}

		async void OnMultipleRotationAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new MultipleRotationAnimationPageCS ());
		}

		async void OnScaleAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ScaleAnimationPageCS ());
		}

		async void OnRelativeScaleAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new RelativeScaleAnimationPageCS ());
		}

		async void OnTransformAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new TransformAnimationPageCS ());
		}

		async void OnFadeAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new FadeAnimationPageCS ());
		}
	}
}
