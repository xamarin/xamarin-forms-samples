using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NativeSwitch
{
	public class NativeSwitchPageViewModel : INotifyPropertyChanged
	{
		bool isSwitchOn;
		public bool IsSwitchOn
		{
			get { return isSwitchOn; }
			set
			{
				if (isSwitchOn != value)
				{
					isSwitchOn = value;
					OnPropertyChanged();
				}
			}
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
