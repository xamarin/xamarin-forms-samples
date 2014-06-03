using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TablesLists
{
	public class ItemsGroup : IEnumerable<Item>
	{
		public string Title { get; set; }

		public List<Item> Items { get; private set; }

		public ItemsGroup (string title)
		{
			Title = title;
			Items = new List<Item> ();
		}

		public ItemsGroup (string title, List<Item> items)
		{
			Title = title;
			Items = items;
		}

		public IEnumerator<Item> GetEnumerator ()
		{
			return Items.GetEnumerator ();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return Items.GetEnumerator ();
		}

		public static ObservableCollection<ItemsGroup> GroupAlphabetically (IEnumerable<Item> items)
		{
			var itemsGroups = new Dictionary<string, ItemsGroup> ();

			foreach (var p in items.OrderBy (x => x.Title)) {
				var titleLetter = p.Title.Substring (0, 1).ToUpperInvariant ();
				ItemsGroup itemsGroup;

				if (!itemsGroups.TryGetValue (titleLetter, out itemsGroup)) {
					itemsGroup = new ItemsGroup (titleLetter);
					itemsGroups.Add (titleLetter, itemsGroup);
				}

				itemsGroup.Items.Add (p);
			}

			return new ObservableCollection<ItemsGroup> (itemsGroups.Values.OrderBy (x => x.Title));
		}
	}

	public class Item
	{
		public string Title { get; set; }

		public string NavigationPage { get; set; }

		public string ItemsSourceFile { get; set; }

		public string Subtitle { get; set; }

		public string ImageSource { get; set; }
	}
}

