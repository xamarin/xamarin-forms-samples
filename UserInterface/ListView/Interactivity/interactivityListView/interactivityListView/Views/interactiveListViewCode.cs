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
			items = new ObservableCollection<string> () { "Speaker", "Pen", "Lamp", "Monitor", "Bag", "Book", "Cap", "Tote", "Floss", "Phone"};

            ListView lstView = new ListView();
			lstView.IsPullToRefreshEnabled = true;
			lstView.Refreshing += OnRefresh;
			lstView.ItemSelected += OnSelection;
			lstView.ItemTapped += OnTap;
			lstView.ItemsSource = items;
            //lstView.SelectionMode = ListViewSelectionMode.None;
			var temp = new DataTemplate (typeof(textViewCell));
			lstView.ItemTemplate = temp;

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "ListView Interactivity", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                    lstView
                }
            };
		}

		void OnTap (object sender, ItemTappedEventArgs e)
		{
			DisplayAlert ("Item Tapped", e.Item.ToString (), "Ok");
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
            {
				return;
			}
			DisplayAlert ("Item Selected", e.SelectedItem.ToString (), "Ok");
		}

		void OnRefresh (object sender, EventArgs e)
		{
			var list = (ListView)sender;
			//put your refreshing logic here
			var itemList = items.Reverse().ToList();
			items.Clear ();
			foreach (var s in itemList) 
            {
				items.Add (s);
			}
			//make sure to end the refresh state
			list.IsRefreshing = false;
		}
	}

	public class textViewCell : ViewCell
    {
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


