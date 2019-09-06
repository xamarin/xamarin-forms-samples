using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace builtInCellsListView
{
	public partial class ListViewXaml : ContentPage
	{
		private ObservableCollection<VeggieModel> veggies { get; set; }
		public ListViewXaml ()
		{
			InitializeComponent ();
			lstView.ItemsSource = Constants.Veggies;
		}
	}
}

