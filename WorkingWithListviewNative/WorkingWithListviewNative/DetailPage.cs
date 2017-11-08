using System;

using Xamarin.Forms;

namespace WorkingWithListviewNative
{
	public class DetailPage : ContentPage
	{
		public DetailPage (object detail)
		{
			var l = new Label { Text = "Xamarin.Forms Detail Page" };

			var t = new Label ();

			if (detail is string) {
				t.Text = (string)detail;
			} else if (detail is DataSource) {
				t.Text = ((DataSource)detail).Name;
			}

			var b = new Button { Text = "Dismiss" };
			b.Clicked += (sender, e) => Navigation.PopModalAsync();

			Content = new StackLayout {
				Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions =  LayoutOptions.Center,
				Children = {
					l,
					t,
					b
				}
			};
		}
	}
}
