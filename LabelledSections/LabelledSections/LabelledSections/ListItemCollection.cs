using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelledSections
{
    // Represents a group of items in our list.
    public class ListItemCollection : ObservableCollection<ListItemValue>
    {
        public string Title { get; private set; }

        public ListItemCollection(string title)
        {
            Title = title;
        }

        public static List<ListItemValue> GetSortedData()
        {
            var items = ListItems;
            items.Sort();
            return items;
        }

        // Data used to populate our list.
        static readonly List<ListItemValue> ListItems = new List<ListItemValue>() {
			new ListItemValue ("Babbage"),
			new ListItemValue ("Boole"),
			new ListItemValue ("Berners-Lee"),
			new ListItemValue ("Atanasoff"),
			new ListItemValue ("Allen"),
			new ListItemValue ("Cormack"),
			new ListItemValue ("Cray"),
			new ListItemValue ("Dijkstra"),
			new ListItemValue ("Dix"),
			new ListItemValue ("Dewey"),
			new ListItemValue ("Erdos"),
		};
    }
}
