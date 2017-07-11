using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
	public class AndroidSoftInputModeAdjustPageCS : ContentPage
	{
		public AndroidSoftInputModeAdjustPageCS()
		{
			Title = "Soft Input Mode Adjust";

			var panButton = new Button { Text = "Pan" };
			panButton.Clicked += OnPanButtonClicked;
			var resizeButton = new Button { Text = "Resize " };
			resizeButton.Clicked += OnResizeButtonClicked;

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children =
				{
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.Center,
						Children = { panButton, resizeButton }
					},
					new Entry { Placeholder = "Enter text here", VerticalOptions = LayoutOptions.EndAndExpand }
				}
			};
		}

		void OnPanButtonClicked(object sender, EventArgs e)
		{
			App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
		}

		void OnResizeButtonClicked(object sender, EventArgs e)
		{
			App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
		}
	}
}
