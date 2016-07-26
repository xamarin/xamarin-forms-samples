using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace twoWayBinding
{
	public class light : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _name;
		private string _comment;
		private Color _color;
		private bool _isOn;
		public string name { get{ return _name;} set{ OnPropertyChanged (); _name = value;} }
		public string comment { get{return _comment;} set{OnPropertyChanged ();_comment = value;} }
		public Color color { get{ return _color;} set{ OnPropertyChanged (); _color = value;} }
		public bool isOn { get{ return _isOn;} set{OnPropertyChanged (); OnPropertyChanged ("isNotOn"); _isOn = value;} }
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

