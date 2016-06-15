using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace FormsListViewSample
{
	
	public partial class MainViewXaml : ContentPage
	{
		public ObservableCollection<VeggieViewModel> veggies { get; set; }
		public MainViewXaml ()
		{
			
			veggies = new ObservableCollection<VeggieViewModel> ();
			InitializeComponent ();
			lstView.ItemsSource = veggies;
			veggies.Add (new VeggieViewModel{ Name="Tomato", Type="Fruit", Image="tomato.png"});
			veggies.Add (new VeggieViewModel{ Name="Romaine Lettuce", Type="Vegetable", Image="lettuce.png"});
			veggies.Add (new VeggieViewModel{ Name="Zucchini", Type="Vegetable", Image="zucchini.png"});
		}
	}
}

