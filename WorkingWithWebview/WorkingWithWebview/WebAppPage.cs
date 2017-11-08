using System;
using Xamarin.Forms;

namespace WorkingWithWebview
{
	public class WebAppPage : ContentPage
	{
		public WebAppPage ()
		{
			var l = new Label {
				Text = "These buttons leave the current app and open the built-in web browser app for the platform"
			};

			var openUrl = new Button {
				Text = "Open location using built-in Web Browser app"
			};
			openUrl.Clicked += (sender, e) => {
				if (Device.RuntimePlatform != Device.WinPhone){
					Device.OpenUri(new Uri("http://xamarin.com/evolve"));
				} else {
					DisplayAlert("To Do","Not implemented yet","OK");
				}
			};

			var makeCall = new Button {
				Text = "Make call using built-in Phone app"
			};
			makeCall.Clicked += (sender, e) => {

				if (Device.RuntimePlatform != Device.WinPhone){
					Device.OpenUri(new Uri("tel:1855XAMARIN"));
				} else {
					DisplayAlert("To Do","Not implemented yet","OK");
				}
			};

			Content = new StackLayout{
				Padding = new Thickness (5, 20, 5, 0),
				HorizontalOptions = LayoutOptions.Fill,
				Children = {
					l,
					openUrl,
					makeCall
				}
			};
		}
	}
}
