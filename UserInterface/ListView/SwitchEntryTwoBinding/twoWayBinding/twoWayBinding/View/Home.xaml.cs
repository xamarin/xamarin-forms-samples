using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace twoWayBinding
{
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
		}

		void OnEditTap (object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new SwitchPage ());
		}

		void OnNameTap (object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new EntryPage ());
		}

		void listSelection(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}

