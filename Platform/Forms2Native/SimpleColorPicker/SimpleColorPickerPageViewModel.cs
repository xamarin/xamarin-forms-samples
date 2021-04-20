using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SimpleColorPicker
{
	public class SimpleColorPickerPageViewModel : INotifyPropertyChanged
	{
		double red;
		public double Red
		{
			get { return red; }
			set
			{
				if (red != value)
				{
					red = value;
					OnPropertyChanged();
					OnPropertyChanged("SelectedColor");
				}
			}
		}

		double green;
		public double Green
		{
			get { return green; }
			set
			{
				if (green != value)
				{
					green = value;
					OnPropertyChanged();
					OnPropertyChanged("SelectedColor");
				}
			}
		}

		double blue;
		public double Blue
		{
			get { return blue; }
			set
			{
				if (blue != value)
				{
					blue = value;
					OnPropertyChanged();
					OnPropertyChanged("SelectedColor");
				}
			}
		}

		public Color SelectedColor
		{
			get { return Color.FromRgb(red, green, blue); }
			set
			{
				Red = value.R;
				Green = value.G;
				Blue = value.B;
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
