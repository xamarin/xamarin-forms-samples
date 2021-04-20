using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BindingContextChanged
{
	public partial class ListPage : ContentPage
	{
		public ListPage ()
		{
			InitializeComponent ();
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			listView.ItemsSource = Constants.People;
		}
	}
}

