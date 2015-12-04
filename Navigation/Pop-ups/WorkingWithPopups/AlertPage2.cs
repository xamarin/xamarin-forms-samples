using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithPopups
{
	public class AlertPage : ContentPage
	{
		public AlertPage ()
		{
			var label = new Label {
				Text="DisplayAlert",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
			};

			var alertButton1 = new Button { Text = "Alert Simple" };
			alertButton1.Clicked += async (sender, e) => {
				await DisplayAlert ("Alert", "You have been alerted", "OK");
			};

			var alertButton2 = new Button { Text = "Alert Yes/No" }; // triggers alert
			alertButton2.Clicked += async (sender, e) => {
				var answer = await DisplayAlert ("Question?", "Would you like to play a game", "Yes", "No");
				Debug.WriteLine("Answer: " + answer); // writes true or false to the console
			};

			Content = new StackLayout {
				Padding = new Thickness(0,20,0,0),
				Children = {
					label,
					alertButton1,
					alertButton2
				}
			};
		}
	}
}

