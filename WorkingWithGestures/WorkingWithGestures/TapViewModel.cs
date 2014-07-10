using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace WorkingWithGestures
{
	/// <summary>
	/// ViewModel to demonstrate binding to a Command from a GestureRecognizer
	/// </summary>
	/// <remarks>
	/// View models can be used regardless of whether the UI is build in code or with Xaml.
	/// In this example the view model is referenced by a Xaml page, but the same bindings
	/// can be done in C#.
	/// </remarks>
	public class TapViewModel : INotifyPropertyChanged
	{
		ICommand tapCommand;
		int taps = 0;
		string numberOfTapsTapped;

		public TapViewModel ()
		{
			// configure the TapCommand with a method
			tapCommand = new Command (OnTapped);
		}

		/// <summary>
		/// Expose the TapCommand via a property so that Xaml can bind to it
		/// </summary>
		public ICommand TapCommand
		{
			get { return tapCommand; }
		}

		/// <summary>
		/// Called whenever TapCommand is executed (because it was wired up in the constructor)
		/// </summary>
		void OnTapped (object s) {
			taps++;
			Debug.WriteLine ("parameter: " + s);
			NumberOfTapsTapped = String.Format("{0} tap{1} so far!",
				taps, 
				taps == 1 ? "" : "s");
		}

		/// <summary>
		/// Display string that is bound to a Label on the page
		/// </summary>
		public string NumberOfTapsTapped
		{
			get { return numberOfTapsTapped; }
			set {
				if (numberOfTapsTapped == value)
					return;
				numberOfTapsTapped = value;
				OnPropertyChanged ();
			}
		}

		#region INotifyPropertyChanged 
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler (this, new PropertyChangedEventArgs (propertyName));
		}
		#endregion
	}
}

