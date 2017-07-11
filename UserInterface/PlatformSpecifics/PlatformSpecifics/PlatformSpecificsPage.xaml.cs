using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
	public partial class PlatformSpecificsPage : ContentPage
	{
		public PlatformSpecificsPage()
		{
			InitializeComponent();
		}

		async void OnBlurEffectButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new iOSBlurEffectPage());
		}

		async void OnTranslucentNavigationBarButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
		}

		async void OnEntryFontSizeChangesButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new iOSEntryPage());
		}

		async void OnHideStatusBarButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new iOSStatusBarPage());
		}

		async void OnSoftInputModeAdjustButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AndroidSoftInputModeAdjustPage());
		}

		async void OnPageLifecycleEventsButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AndroidLifecycleEventsPage());
		}

		async void OnTabbedPageButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
		}

		async void OnNavigationPageButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
		}

		async void OnMasterDetailPageButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
		}
	}
}
