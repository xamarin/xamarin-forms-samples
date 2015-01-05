using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorkingWithListview
{
	public partial class ContextActionsXaml : ContentPage
	{
		public ContextActionsXaml ()
		{
			InitializeComponent ();

			listView.ItemsSource = new [] { "alpha", "beta", "gamma", "delta" };
		}

		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
			DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
			((ListView)sender).SelectedItem = null; // de-select the row
		}

		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}
	}
}

