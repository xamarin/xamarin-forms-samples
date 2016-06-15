using System;
using System.ComponentModel;

namespace FormsListViewSample
{
	public class VeggieViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		public string Name { get; set; }
		public string Type { get; set; }
		public string Image { get; set; }
		public VeggieViewModel ()
		{
		}


	}
}

