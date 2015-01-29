using System;

using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class Page4 : ContentPage
	{
		public Page4 ()
		{
			var prev = new Button { Text = "Prev" };
			prev.Clicked += async (sender, e) => {
				await Navigation.PopAsync();
			};


			var insert = new Button { Text = "Insert Page3a before this" };
			insert.Clicked += (sender, e) => {
				Navigation.InsertPageBefore (new Page3a(), Navigation.NavigationStack[3]);
			};
			var remove = new Button { Text = "Remove Page3" };
			remove.Clicked += (sender, e) => {
				Navigation.RemovePage(Navigation.NavigationStack[2]);
			};



			Title = "Page 4";
			Content = new StackLayout { 
				BackgroundColor = Color.Purple,
				Children = {
					new Label { Text = "Page 4", FontSize=Device.GetNamedSize(NamedSize.Large, typeof(Label)) }
					, insert, remove

					, new Label { Text = "Edit the stack before hitting previous or the back button" }
					, prev
				}
			};
		}
	}
}


