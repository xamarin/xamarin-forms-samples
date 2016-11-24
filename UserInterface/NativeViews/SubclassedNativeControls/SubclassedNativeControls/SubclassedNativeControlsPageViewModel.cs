using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SubclassedNativeControls
{
	public class SubclassedNativeControlsPageViewModel : INotifyPropertyChanged
	{

		IList<string> fruits;
		public IList<string> Fruits
		{
			get { return fruits; }
			private set { fruits = value; }
		}

		string selectedFruit = "Apple";
		public string SelectedFruit
		{
			get { return selectedFruit; }
			set
			{
				if (selectedFruit != value)
				{
					selectedFruit = value;
					OnPropertyChanged();
				}
			}
		}

		public SubclassedNativeControlsPageViewModel()
		{
			Fruits = new List<string>
			{
				"Apple", "Apricot", "Banana", "Cherry",
				"Clementine", "Date", "Fig", "Grape",
				"Guava", "Lemon", "Mango", "Melon",
				"Nectarine", "Orange", "Pear", "Pineapple",
				"Plum", "Satsuma", "Strawberry"
			};
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
