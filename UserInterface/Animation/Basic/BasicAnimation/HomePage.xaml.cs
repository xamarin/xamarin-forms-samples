using System;
using Xamarin.Forms;

namespace BasicAnimation
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

		async void OnRotateAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new RotateAnimationPage ());
		}

		async void OnRelativeRotateAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new RelativeRotationPage ());
		}

		async void OnRotateAnimationWithAnchorsButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new RotateAnimationWithAnchorsPage ());
		}

		async void OnMultipleRotationAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new MultipleRotationAnimationPage ());
		}

		async void OnScaleAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ScaleAnimationPage ());
		}

		async void OnRelativeScaleAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new RelativeScaleAnimationPage ());
		}

		async void OnTransformAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new TransformAnimationPage ());
		}

		async void OnFadeAnimationButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new FadeAnimationPage ());
		}
	}
}

