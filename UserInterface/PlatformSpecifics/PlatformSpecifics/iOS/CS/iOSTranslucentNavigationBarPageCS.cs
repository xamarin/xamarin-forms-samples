using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
	public class iOSTranslucentNavigationBarPageCS : ContentPage
	{
		public iOSTranslucentNavigationBarPageCS()
		{
			var button = new Button { Text = "Toggle Translucent Navigation Bar " };
			button.Clicked += (sender, e) => (App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().SetIsNavigationBarTranslucent(!(App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().IsNavigationBarTranslucent());

			Title = "Navigation Bar";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = { button }
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			(App.Current.MainPage as Xamarin.Forms.NavigationPage).BackgroundColor = Color.Blue;
			(App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().EnableTranslucentNavigationBar();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			(App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().DisableTranslucentNavigationBar();
		}
	}
}
