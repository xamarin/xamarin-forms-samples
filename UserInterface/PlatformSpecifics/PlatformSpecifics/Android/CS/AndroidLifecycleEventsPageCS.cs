using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace PlatformSpecifics
{
	public class AndroidLifecycleEventsPageCS : ContentPage
	{
		public AndroidLifecycleEventsPageCS()
		{
			Xamarin.Forms.Application.Current.On<Android>()
				   .UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize)
				   .SendDisappearingEventOnPause(false)
				   .SendAppearingEventOnResume(false)
				   .ShouldPreserveKeyboardOnResume(false);

			var button = new Xamarin.Forms.Button { Text = "Toggle Pause and Resume Events" };
			button.Clicked += (sender, e) =>
			{
				Xamarin.Forms.Application.Current.On<Android>()
					   .SendDisappearingEventOnPause(!Xamarin.Forms.Application.Current.On<Android>().GetSendDisappearingEventOnPause())
					   .SendAppearingEventOnResume(!Xamarin.Forms.Application.Current.On<Android>().GetSendAppearingEventOnResume())
					   .ShouldPreserveKeyboardOnResume(!Xamarin.Forms.Application.Current.On<Android>().GetShouldPreserveKeyboardOnResume());
			};
			Title = "Pause/Resume Lifecycle Events";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new Label { Text = "Pause the app and then resume it. If the pause and resume events are disabled, the OnAppearing and OnDisappearing overrides won't fire.", HorizontalOptions = LayoutOptions.Center },
					button
				}
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Debug.WriteLine("\r\n\t\tOnAppearing\r\n");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			Debug.WriteLine("\r\n\t\tOnDisappearing\r\n");
		}
	}
}
