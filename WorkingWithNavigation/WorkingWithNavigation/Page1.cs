using System;

using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class Page1 : ContentPage
	{
		public Page1 ()
		{
			var b = new Button { Text = "Next" };
			b.Clicked += async (sender, e) => {
				await Navigation.PushAsync (new Page2());
			};
			Title = "Page 1";
			Content = new StackLayout { 
				BackgroundColor = Color.Red,
				Children = {
					new Label { Text = "Page 1", FontSize=Device.GetNamedSize(NamedSize.Large, typeof(Label)) }
						, b
				}
			};
		}
	}
}


