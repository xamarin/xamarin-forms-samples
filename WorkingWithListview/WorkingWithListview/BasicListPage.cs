using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
	/// <summary>
	/// Very simple example of a ListView, demonstrating how to 'unselect'
	/// the row after tapping 
	/// </summary>
	public class BasicListPage : ContentPage
	{
		public BasicListPage ()
		{
			var listView = new ListView ();

			listView.ItemsSource = new [] { "a", "b", "c" };

			listView.ItemTapped += (sender, e) => {
				if (e == null) return; // has been set to null, do not 'process' tapped event
				Debug.WriteLine("Tapped: " + e.Item);
				((ListView)sender).SelectedItem = null; // de-select the row
			};
				
			Padding = new Thickness (0,20,0,0);
			Content = listView;
		}
	}
}
