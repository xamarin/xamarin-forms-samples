using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicFormsListView
{
	public partial class ListViewXaml : ContentPage
	{
		public ListViewXaml ()
		{
			InitializeComponent ();
            lstView.ItemsSource = Constants.Items;
		}
	}
}

