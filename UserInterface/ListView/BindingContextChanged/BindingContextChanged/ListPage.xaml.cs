using System.Collections.Generic;
using Xamarin.Forms;

namespace BindingContextChanged
{
	public partial class ListPage : ContentPage
	{
		public ListPage ()
		{
			InitializeComponent ();
			listView.ItemsSource = new List<string> { "Apples", "Oranges", "Pears", "Bananas", "Mangos" };
		}
	}
}

