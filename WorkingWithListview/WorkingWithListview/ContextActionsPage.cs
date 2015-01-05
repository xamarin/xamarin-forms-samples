using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
	/// <summary>
	/// Demonstrates the new ContextActions property introduced in Xamarin.Forms 1.3
	/// </summary>
	public class ContextActionsPage : ContentPage
	{
		public ContextActionsPage ()
		{
			var listView = new ListView ();

			listView.ItemsSource = new [] { "alpha", "beta", "gamma", "delta" };
			listView.ItemTemplate = new DataTemplate(typeof(ContextActionsCell)); // has context actions defined

			// Using ItemTapped
			listView.ItemTapped += async (sender, e) => {
				Debug.WriteLine("Tapped: " + e.Item);
				await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
				((ListView)sender).SelectedItem = null; // de-select the row
			};
				
			Padding = new Thickness (0,20,0,0);
			Content = listView;
		}
	}
}


