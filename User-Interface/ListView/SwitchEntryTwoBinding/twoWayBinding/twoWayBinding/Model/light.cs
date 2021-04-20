using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace twoWayBinding
{
    public class light : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _name;
		private string _comment;
		private Color _color;
		private bool _isOn;

		public string name
		{
			get	{ return _name;}
			set
			{
				_name = value;
				OnPropertyChanged();
			}
		}

		public string comment
		{
			get{return _comment;}
			set
			{
				_comment = value;
				OnPropertyChanged();
			}
		}

		public Color color
		{
			get{ return _color;}
			set
			{
				_color = value;
				OnPropertyChanged();
			}
		}

		public bool isOn
		{
			get{ return _isOn;}
			set
			{
				_isOn = value;
				OnPropertyChanged ();
				OnPropertyChanged ("isNotOn");
			}
		}

		public bool isNotOn{ get { return !_isOn; } }

		public light ()
		{
			this.isOn = false;
			this.name = "My first light!";
			this.color = Color.Blue;
			this.comment = "Bedroom";
		}

		public light(bool isOn, string name, Color color, string comment)
		{
			this.isOn = isOn;
			this.name = name;
			this.color = color;
			this.comment = comment;
		}

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

