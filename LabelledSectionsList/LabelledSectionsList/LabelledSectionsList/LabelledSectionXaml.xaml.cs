using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace LabelledSections
{
	public partial class LabelledSectionXaml : ContentPage
	{
		public LabelledSectionXaml ()
		{
			InitializeComponent ();

			var list = SetupList ();
			itemListView.ItemsSource = list;
		}

		void OnItemTapped (object sender, ItemTappedEventArgs ea) {
			var listItem = (ListItemValue)ea.Item;
			DisplayAlert(listItem.Name, "You tapped " + listItem.Name, "OK", "Cancel");
		}

		ObservableCollection<ListItemCollection> SetupList()
		{
			var allListItemGroups = new ObservableCollection<ListItemCollection>();

			foreach (var item in ListItemCollection.GetSortedData())
			{
				// Attempt to find any existing groups where theg group title matches the first char of our ListItem's name.
				var listItemGroup = allListItemGroups.FirstOrDefault(g => g.Title == item.Label);

				// If the list group does not exist, we create it.
				if (listItemGroup == null)
				{
					listItemGroup = new ListItemCollection(item.Label);
					listItemGroup.Add(item);
					allListItemGroups.Add(listItemGroup);
				}
				else
				{ // If the group does exist, we simply add the demo to the existing group.
					listItemGroup.Add(item);
				}
			}
			return allListItemGroups;
		}
	}
}

