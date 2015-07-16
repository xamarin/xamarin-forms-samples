using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace groupingSampleListView
{
	public class veggieModel
	{
		public string name { get; set; }
		public string comment { get; set; }
		public bool isReallyAVeggia { get; set; }
		public string image { get; set; }
		public veggieModel ()
		{
		}
	}

	public class groupedVeggieModel : ObservableCollection<veggieModel>
	{
		public string longName { get; set; }
		public string shortName { get; set; }
	}
}

