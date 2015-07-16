using System;

using Xamarin.Forms;

namespace twoWayBinding
{
	public class EntryPageCode : ContentPage
	{
		public EntryPageCode ()
		{
			ListView listView = new ListView (){ SeparatorVisibility = SeparatorVisibility.None, ItemsSource = HomeViewModel.lights};
			listView.ItemTemplate = new DataTemplate (typeof(EntryCell));
			listView.ItemTemplate.SetBinding (EntryCell.LabelProperty, "comment");
			listView.ItemTemplate.SetBinding (EntryCell.TextProperty, "name");
			Content = listView;
		}
	}
}


