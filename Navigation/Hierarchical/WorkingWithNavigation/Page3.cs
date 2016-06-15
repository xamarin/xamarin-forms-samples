using System;
using System.Linq;
using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class Page3 : ContentPage
	{
		public Page3 ()
		{
			var previousPageButton = new Button { Text = "Previous Page", VerticalOptions = LayoutOptions.CenterAndExpand };
			previousPageButton.Clicked += OnPreviousPageButtonClicked;

			var rootPageButton = new Button { Text = "Return to Root Page", VerticalOptions = LayoutOptions.CenterAndExpand };
			rootPageButton.Clicked += OnRootPageButtonClicked;

			var insertPageButton = new Button {
				Text = "Insert Page 2a Before Page 3",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			insertPageButton.Clicked += OnInsertPageButtonClicked;

			var removePageButton = new Button { Text = "Remove Page 2", VerticalOptions = LayoutOptions.CenterAndExpand };
			removePageButton.Clicked += OnRemovePageButtonClicked;

			Title = "Page 3";
			Content = new StackLayout { 
				Children = {
					previousPageButton,
					rootPageButton,
					insertPageButton,
					removePageButton
				}
			};
		}

		async void OnPreviousPageButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}

		async void OnRootPageButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopToRootAsync ();
		}

		void OnInsertPageButtonClicked (object sender, EventArgs e)
		{
			var page2a = Navigation.NavigationStack.FirstOrDefault (p => p.Title == "Page 2a");
			if (page2a == null) {
				Navigation.InsertPageBefore (new Page2a (), this);
			}
		}

		void OnRemovePageButtonClicked (object sender, EventArgs e)
		{
			var page2 = Navigation.NavigationStack.FirstOrDefault (p => p.Title == "Page 2");
			if (page2 != null) {
				Navigation.RemovePage (page2);
			}
		}
	}
}
