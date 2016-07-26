using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace interactivityListView
{
	public class interactiveListViewCode : ContentPage
	{
		public static ObservableCollection<string> items { get; set; }
		public interactiveListViewCode ()
		{
			items = new ObservableCollection<string> () { "speaker", "pen", "lamp", "monitor", "bag", "book", "cap", "tote", "floss", "phone"};
			ListView lstView = new ListView ();
			lstView.IsPullToRefreshEnabled = true;
			lstView.Refreshing += OnRefresh;
			lstView.ItemSelected += OnSelection;
			lstView.ItemTapped += OnTap;
			lstView.ItemsSource = items;
			var temp = new DataTemplate (typeof(textViewCell));
			lstView.ItemTemplate = temp;
			Content = lstView;
		}

		void OnTap (object sender, ItemTappedEventArgs e)
		{
			DisplayAlert ("Item Tapped", e.Item.ToString (), "Ok");
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			DisplayAlert ("Item Selected", e.SelectedItem.ToString (), "Ok");
			//comment out if you want to keep selections
			ListView lst = (ListView)sender;
			lst.SelectedItem = null;
		}

		void OnRefresh (object sender, EventArgs e)
		{
			var list = (ListView)sender;
			//put your refreshing logic here
			var itemList = items.Reverse().ToList();
			items.Clear ();
			foreach (var s in itemList) {
				items.Add (s);
			}
			//make sure to end the refresh state
			list.IsRefreshing = false;
		}


	}

	public class textViewCell : ViewCell{
		public textViewCell()
		{
			StackLayout layout = new StackLayout ();
			layout.Padding = new Thickness (15, 0);
			Label label = new Label ();

			label.SetBinding (Label.TextProperty, ".");
			layout.Children.Add (label);

			var moreAction = new MenuItem { Text = "More" };
			moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			moreAction.Clicked += OnMore;

			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			deleteAction.Clicked += OnDelete;

			this.ContextActions.Add (moreAction);
			this.ContextActions.Add (deleteAction);
			View = layout;
		}

		void OnMore (object sender, EventArgs e)
		{
			var item = (MenuItem)sender;
			//Do something here... e.g. Navigation.pushAsync(new specialPage(item.commandParameter));
			//page.DisplayAlert("More Context Action", item.CommandParameter + " more context action", 	"OK");
		}

		void OnDelete (object sender, EventArgs e)
		{
			var item = (MenuItem)sender;
			interactiveListViewCode.items.Remove (item.CommandParameter.ToString());
		}
	}
}


