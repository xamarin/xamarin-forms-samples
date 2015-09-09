using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TextSample
{
	public partial class ListPage : ContentPage
	{
		public ListPage ()
		{
			InitializeComponent ();
			List<Page> pages = new List<Page> ();
			pages.Add (new EditorPage ());
			pages.Add (new EditorPageCode ());
			pages.Add (new EntryPage ());
			pages.Add (new EntryPageCode ());
			pages.Add (new LabelPage ());
			pages.Add (new LabelPageCode ());
			ListOfPages.ItemsSource = pages;

		}

		private void itemSelected(object sender, SelectedItemChangedEventArgs e){
			if (e.SelectedItem != null) {
				this.Navigation.PushAsync ((Page)e.SelectedItem);
			}
			ListOfPages.SelectedItem = null;
		}
	}
}

