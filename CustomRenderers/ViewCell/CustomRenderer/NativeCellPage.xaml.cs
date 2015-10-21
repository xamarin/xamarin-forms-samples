using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomRenderer
{
	/// <summary>
	/// This page uses the built-in Xamarin.Forms controls to display a fast-scrolling list.
	/// 
	/// It uses a custom renderer for the ViewCell. This removes the Xamarin.Forms layout
	/// calculations from being repeatedly called during scrolling.
	/// </summary>
	public partial class NativeCellPage : ContentPage
	{
		public NativeCellPage ()
		{
			InitializeComponent ();

			listView.ItemsSource = DataSource.GetList ();
		}

		async void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return;
			}

			// Deselect row
			listView.SelectedItem = null;

			await Navigation.PushModalAsync (new DetailPage (e.SelectedItem));
		}
	}
}
