using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicFormsListView
{
	public partial class ListViewXaml : ContentPage
	{
		public ListViewXaml ()
		{
			InitializeComponent ();
			lstView.ItemsSource = new List<string> () { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
		}
	}
}

