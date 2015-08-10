using System;

namespace builtInCellsListView
{
	public class veggieModel
	{
		public string name { get; set ; }
		public string comment { get; set; }
		public bool isReallyAVeggie { get; set; } //set false for de jure vegetables, like pizza
		public string image {get; set;}

		public veggieModel ()
		{
		}
	}
}

