using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class ColorAnimationPage : ContentPage
	{
		public ColorAnimationPage()
		{
			InitializeComponent();
		}

		void SetIsEnabledCancelButtonState(bool cancelButtonState)
		{
			cancelButton.IsEnabled = cancelButtonState;
		}

		async void OnAnimateLabelButtonClicked(object sender, EventArgs e)
		{
			SetIsEnabledCancelButtonState(true);

			await Task.WhenAll(
				label.ColorTo(Color.Red, Color.Blue, c => label.TextColor = c, 5000),
				label.ColorTo(Color.Blue, Color.Red, c => label.BackgroundColor = c, 5000));

			label.BackgroundColor = Color.Default;
			label.TextColor = Color.Default;
		}

		async void OnAnimatePageBackgroundButtonClicked(object sender, EventArgs e)
		{
			SetIsEnabledCancelButtonState(true);

			await this.ColorTo(Color.FromRgb(0, 0, 0), Color.FromRgb(255, 255, 255), c => BackgroundColor = c, 5000);
			BackgroundColor = Color.Default;
		}

		async void OnAnimateBoxViewButtonClicked(object sender, EventArgs e)
		{
			SetIsEnabledCancelButtonState(true);

			await boxView.ColorTo(Color.Blue, Color.Red, c => boxView.Color = c, 4000);
		}

		void OnCancelAnimationButtonClicked(object sender, EventArgs e)
		{
			boxView.CancelAnimation();
			label.CancelAnimation();
			this.CancelAnimation();

			SetIsEnabledCancelButtonState(false);
		}
	}
}
