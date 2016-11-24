using Xamarin.Forms;

namespace PlatformSpecifics
{
	public class PlatformSpecificsPageCS : ContentPage
	{
		public PlatformSpecificsPageCS()
		{
			var blurButton = new Button { Text = "Blur Effect (iOS only)" };
			blurButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSBlurEffectPageCS());
			var translucentButton = new Button { Text = "Translucent Navigation Bar (iOS only) " };
			translucentButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
			var inputModeButton = new Button { Text = "Soft Input Mode Adjust (Android only)" };
			inputModeButton.Clicked += async (sender, e) => await Navigation.PushAsync(new AndroidSoftInputModeAdjustPageCS());
			var tabbedPageButton = new Button { Text = "Tabbed Page Toolbar Location Adjust (Windows only)" };
			tabbedPageButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
			var navigationPageButton = new Button { Text = "Navigation Page Toolbar Location Adjust (Windows only)" };
			navigationPageButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
			var masterDetailPageButton = new Button { Text = "Master Detail Page Toolbar Location Adjust (Windows only)" };
			masterDetailPageButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");

			Title = "Platform Specifics Demo";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = { blurButton, translucentButton, inputModeButton, tabbedPageButton, navigationPageButton, masterDetailPageButton }
			};
		}
	}
}

