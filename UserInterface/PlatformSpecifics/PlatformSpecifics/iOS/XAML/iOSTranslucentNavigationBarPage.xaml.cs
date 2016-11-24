using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
	public partial class iOSTranslucentNavigationBarPage : ContentPage
	{
		public iOSTranslucentNavigationBarPage()
		{
			InitializeComponent();
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			(App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().SetIsNavigationBarTranslucent(!(App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().IsNavigationBarTranslucent());
		}
	}
}
