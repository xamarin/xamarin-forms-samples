using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace WorkingWithListview
{
	public partial class ContextActionsXaml : ContentPage
	{

		ObservableCollection<string> items;
		public ContextActionsXaml ()
		{
			InitializeComponent ();

			items = new ObservableCollection<string> { "alpha", "beta", "gamma", "delta", "epsilon" };
			//listView.ItemsSource = items;
			listView.SetBinding (ListView.ItemsSourceProperty, new Binding ("."));
			listView.BindingContext = items;
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
			//DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");

			Debug.WriteLine ("delete " + mi.CommandParameter.ToString ());
			items.Remove (mi.CommandParameter.ToString());
		}
	}
}

