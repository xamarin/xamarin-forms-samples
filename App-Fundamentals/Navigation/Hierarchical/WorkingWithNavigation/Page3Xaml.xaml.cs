using System;
using System.Linq;
using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public partial class Page3Xaml : ContentPage
	{
		public Page3Xaml ()
		{
			InitializeComponent ();
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
				Navigation.InsertPageBefore (new Page2aXaml (), this);
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
