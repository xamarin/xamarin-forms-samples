using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LabelledSections
{
    public class LabelledSectionPage : ContentPage
    {
        public LabelledSectionPage()
        {
			Padding = new Thickness (0, 20, 0, 0);

            var list = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(TextCell))
                {
                    Bindings = {
							{ TextCell.TextProperty, new Binding ("Name") }
						}
                },

				GroupDisplayBinding = new Binding("LongTitle"),
				GroupShortNameBinding = new Binding("Title"),
				Header = "HEADER",
				Footer = "FOOTER",
                IsGroupingEnabled = true,
                ItemsSource = SetupList(),
            };

            list.ItemTapped += (sender, e) =>
            {
                var listItem = (ListItemValue)e.Item;
                DisplayAlert(listItem.Name, "You tapped " + listItem.Name, "OK", "Cancel");
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { list }
            };
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
