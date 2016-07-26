using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace builtInCellsListView
{
	public class ListViewCode : ContentPage
	{
		private ObservableCollection<veggieModel> veggies { get; set; }
		public ListViewCode ()
		{
			veggies = new ObservableCollection<veggieModel> ();
			ListView lstView = new ListView ();
			lstView.ItemsSource = veggies;
			//TODO - uncomment the region for the built-in cell type you'd like to see
			#region textCell
			lstView.ItemTemplate = new DataTemplate (typeof(TextCell));
			lstView.ItemTemplate.SetBinding (TextCell.TextProperty, "name");
			lstView.ItemTemplate.SetBinding (TextCell.DetailProperty, "comment");
			#endregion

			/*#region imageCell
			lstView.ItemTemplate = new DataTemplate (typeof(ImageCell));
			lstView.ItemTemplate.SetBinding (ImageCell.TextProperty, "name");
			lstView.ItemTemplate.SetBinding (ImageCell.DetailProperty, "comment");
			lstView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "image");
			#endregion*/

			/*#region switchCell
			lstView.ItemTemplate = new DataTemplate (typeof(SwitchCell));
			lstView.ItemTemplate.SetBinding (SwitchCell.TextProperty, "name");
			lstView.ItemTemplate.SetBinding (SwitchCell.OnProperty, "isReallyAVeggie");
			#endregion*/

			/*#region entryCell
			lstView.ItemTemplate = new DataTemplate(typeof(EntryCell));
			lstView.ItemTemplate.SetBinding(EntryCell.LabelProperty, "name");
			lstView.ItemTemplate.SetBinding(EntryCell.TextProperty, "comment");
			#endregion*/
			Content = lstView;
			veggies.Add (new veggieModel () { name = "tomato", comment = "actually a fruit", isReallyAVeggie = false, image="tomato.png" });
			veggies.Add (new veggieModel () { name = "pizza", comment = "no comment", isReallyAVeggie = false, image="pizza.png" });
			veggies.Add (new veggieModel () { name = "romaine lettuce", comment = "good in salads", isReallyAVeggie = true, image="lettuce.png" });
			veggies.Add (new veggieModel () { name = "zucchini", comment = "grows relatively easily", isReallyAVeggie = true, image="zucchini.png" });
		}
	}
}


