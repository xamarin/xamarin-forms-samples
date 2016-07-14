using System;
using Xamarin.Forms;

namespace EasingDemo
{
	public class HomePageCS : ContentPage
	{
		Image image;
		Entry entry;
		Picker picker;
		string easingFunctionName;

		public HomePageCS ()
		{
			entry = new Entry { Text = "2000" };
			image = new Image {
				Source = ImageSource.FromFile ("monkey.png"),
				VerticalOptions = LayoutOptions.StartAndExpand
			};
			picker = new Picker ();
			picker.SelectedIndexChanged += OnSelectedPickerIndexChanged;
			var button = new Button { Text = "Run Animation", VerticalOptions = LayoutOptions.End };
			button.Clicked += OnRunAnimationButtonClicked;

			var easingFunctions = Enum.GetNames (typeof(EasingFunction));
			foreach (var function in easingFunctions) {
				picker.Items.Add (function);
			}

			// Ensure Linear easing function is selected
			picker.SelectedIndex = 5;

			Content = new StackLayout { 
				Margin = new Thickness (0, 20, 0, 0),
				Children = {
					image,
					new Label { Text = "Select easing function:" },
					picker,
					new StackLayout {
						Orientation = StackOrientation.Horizontal,
						Children = {
							new Label { Text = "Duration:", VerticalOptions = LayoutOptions.Center },
							entry,
							new Label { Text = "ms", VerticalOptions = LayoutOptions.Center } 
						}	
					},
					button
				}
			};
		}

		async void OnRunAnimationButtonClicked (object sender, EventArgs e)
		{
			if (image.TranslationY != 0) {
				image.TranslationY = 0;
			}

			uint duration = Convert.ToUInt32 (entry.Text);
			await image.TranslateTo (0, 200, duration, GetEasingFunction ());
		}

		void OnSelectedPickerIndexChanged (object sender, EventArgs e)
		{
			easingFunctionName = picker.Items [picker.SelectedIndex];
		}

		Easing GetEasingFunction ()
		{
			EasingFunction easingFunction = EnumUtils.ParseEnum<EasingFunction> (easingFunctionName);

			switch (easingFunction) {
			case EasingFunction.BounceIn:
				return Easing.BounceIn;
			case EasingFunction.BounceOut:
				return Easing.BounceOut;
			case EasingFunction.CubicIn:
				return Easing.CubicIn;
			case EasingFunction.CubicOut:
				return Easing.CubicOut;
			case EasingFunction.CubicInOut:
				return Easing.CubicInOut;
			case EasingFunction.SinIn:
				return Easing.SinIn;
			case EasingFunction.SinOut:
				return Easing.SinOut;
			case EasingFunction.SinInOut:
				return Easing.SinInOut;
			case EasingFunction.SpringIn:
				return Easing.SpringIn;
			case EasingFunction.SpringOut:
				return Easing.SpringOut;
			case EasingFunction.Custom1:
				return new Easing (t => (int)(5 * t) / 5.0);
			case EasingFunction.Custom2:
				return new Easing (t => 9 * t * t * t - 13.5 * t * t + 5.5 * t);
			case EasingFunction.Linear:
			default:
				return Easing.Linear;
			}
		}
	}
}
