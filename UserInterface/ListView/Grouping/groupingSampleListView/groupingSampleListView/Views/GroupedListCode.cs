using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace groupingSampleListView
{
	public class GroupedListCode : ContentPage
	{
		private ObservableCollection<groupedVeggieModel> grouped { get; set; }
		public GroupedListCode ()
		{
			var lstView = new ListView ();
			grouped = new ObservableCollection<groupedVeggieModel> ();
			var veggieGroup = new groupedVeggieModel () { longName = "vegetables", shortName="v" };
			var fruitGroup = new groupedVeggieModel () { longName = "fruit", shortName = "f" };
			veggieGroup.Add (new veggieModel () { name = "celery", isReallyAVeggia = true, comment = "try ants on a log" });
			veggieGroup.Add (new veggieModel () { name = "tomato", isReallyAVeggia = false, comment = "pairs well with basil" });
			veggieGroup.Add (new veggieModel () { name = "zucchini", isReallyAVeggia = true, comment = "zucchini bread > bannana bread" });
			veggieGroup.Add (new veggieModel () { name = "peas", isReallyAVeggia = true, comment = "like peas in a pod" });
			fruitGroup.Add (new veggieModel () {name = "banana", isReallyAVeggia = false,comment = "available in chip form factor"});
			fruitGroup.Add (new veggieModel () {name = "strawberry", isReallyAVeggia = false,comment = "spring plant"});
			fruitGroup.Add (new veggieModel () {name = "cherry", isReallyAVeggia = false,comment = "topper for icecream"});
			grouped.Add (veggieGroup); grouped.Add (fruitGroup);
			lstView.ItemsSource = grouped;
			lstView.IsGroupingEnabled = true;
			lstView.GroupDisplayBinding = new Binding ("longName");
			lstView.GroupShortNameBinding = new Binding ("shortName");
			lstView.ItemTemplate = new DataTemplate (typeof(TextCell));
			lstView.ItemTemplate.SetBinding (TextCell.TextProperty, "name");
			lstView.ItemTemplate.SetBinding (TextCell.DetailProperty, "comment");
			Content = lstView;
		}
	}
}


