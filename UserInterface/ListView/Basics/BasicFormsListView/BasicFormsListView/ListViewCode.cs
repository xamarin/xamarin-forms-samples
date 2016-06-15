using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicFormsListView
{
	public class ListViewCode : ContentPage
	{
		public ListViewCode ()
		{
			var lstView = new ListView ();
			lstView.ItemsSource = new List<String> (){ "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
			Content = lstView;

		}
	}
}


