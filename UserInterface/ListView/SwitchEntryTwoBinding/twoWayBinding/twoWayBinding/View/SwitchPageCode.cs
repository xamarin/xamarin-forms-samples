using System;

using Xamarin.Forms;

namespace twoWayBinding
{
	public class SwitchPageCode : ContentPage
	{
		public SwitchPageCode ()
		{
			ListView listView = new ListView (){SeparatorVisibility = SeparatorVisibility.None, ItemsSource = HomeViewModel.lights};
			listView.ItemTemplate = new DataTemplate (typeof(SwitchCell));
			listView.ItemTemplate.SetBinding (SwitchCell.TextProperty, "name");
			listView.ItemTemplate.SetBinding (SwitchCell.OnProperty, "isOn");
			Content = listView;
			this.Title = "Switch Panel";
		}
	}
}


