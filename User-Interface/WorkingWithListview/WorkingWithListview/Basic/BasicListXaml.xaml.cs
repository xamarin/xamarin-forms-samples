using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{	
	public partial class BasicListXaml : ContentPage
	{	
		public BasicListXaml ()
		{
			InitializeComponent ();

			this.BindingContext = new [] { "a", "b", "c" };
		}

		void OnItemTapped (object sender, ItemTappedEventArgs e) {
			if (e == null) return; // has been set to null, do not 'process' tapped event
			Debug.WriteLine("Tapped: " + e.Item);
			((ListView)sender).SelectedItem = null; // de-select the row
		}
	}
}

