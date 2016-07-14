using System;
using Xamarin.Forms;

namespace BasicAnimation
{
	public class RotateAnimationWithAnchorsPageCS : ContentPage
	{
		AbsoluteLayout absoluteLayout;
		Image image;
		Button startButton, cancelButton;

		public RotateAnimationWithAnchorsPageCS ()
		{
			Title = "Rotate Animation with Anchors";

			image = new Image { Source = ImageSource.FromFile ("monkey.png"), VerticalOptions = LayoutOptions.EndAndExpand };
			startButton = new Button { Text = "Start Animation", VerticalOptions = LayoutOptions.End };
			cancelButton = new Button { Text = "Cancel Animation", IsEnabled = false };

			image.SizeChanged += OnImageSizeChanged;
			startButton.Clicked += OnStartAnimationButtonClicked;
			cancelButton.Clicked += OnCancelAnimationButtonClicked;

			absoluteLayout = new AbsoluteLayout ();
			absoluteLayout.Children.Add (image);

			var stackLayout = new StackLayout {
				Children = {
					startButton,
					cancelButton
				}
			};

			var grid = new Grid { 
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (0.8, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (0.2, GridUnitType.Star) }
				},
				Children = {
					absoluteLayout,
				}
			};

			grid.Children.Add (stackLayout, 0, 1);
			Content = grid;
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


