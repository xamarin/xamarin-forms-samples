using System.Collections.Generic;

namespace MonkeyApp
{
	public class MonkeysPageViewModel : ViewModelBase
	{
		public IList<Monkey> Monkeys { get { return MonkeyData.Monkeys; } }

		Monkey selectedMonkey;
		public Monkey SelectedMonkey
		{
			get { return selectedMonkey; }
			set
			{
				if (selectedMonkey != value)
				{
					selectedMonkey = value;
					OnPropertyChanged();
				}
			}
		}
	}
}
