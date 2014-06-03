using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TablesLists.Data;

namespace TablesLists.ViewModel
{
	public class PageViewModel : ViewModelBase
	{
		public ObservableCollection<ItemsGroup> Groups { get; private set; }

		public PageViewModel (ItemsRepository menuItems)
		{
			Groups = new ObservableCollection<ItemsGroup> (menuItems.Groups);
			OnPropertyChanged ("Groups");
		}
	}
}

