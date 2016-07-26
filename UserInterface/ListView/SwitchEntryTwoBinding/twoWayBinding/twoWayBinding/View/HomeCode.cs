using System;

using Xamarin.Forms;

namespace twoWayBinding
{
	public class HomeCode : ContentPage
	{
		public HomeCode ()
		{
			ListView listView = new ListView ();
			listView.SeparatorVisibility = SeparatorVisibility.None;
			listView.ItemsSource = HomeViewModel.lights;
			listView.ItemSelected += listSelection;
			listView.ItemTemplate = new DataTemplate (typeof(LightViewCell));
			ToolbarItem editItem = new ToolbarItem (){ Text = "Switch" };
			ToolbarItems.Add (editItem);
			editItem.Clicked += OnEditTap;
			ToolbarItem nameItem = new ToolbarItem (){ Text = "Name" };
			ToolbarItems.Add (nameItem);
			nameItem.Clicked += OnNameTap;
			Content = listView;
			this.Title = "MonkeySee Home";
		}

		void OnEditTap (object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new SwitchPageCode ());
		}

		void OnNameTap (object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new EntryPageCode ());
		}

		void listSelection (object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}

	public class LightViewCell : ViewCell
	{
		public LightViewCell()
		{
			StackLayout layout = new StackLayout (){ Padding = new Thickness(2, 15)};
			layout.Orientation = StackOrientation.Horizontal;
			layout.Children.Add (new Image () { HorizontalOptions = LayoutOptions.Start, Source = "bulb.png" });
			Label nameLabel = new Label (){ HorizontalOptions = LayoutOptions.CenterAndExpand };
			nameLabel.SetBinding (Label.TextProperty, "name");
			nameLabel.SetBinding (Label.TextColorProperty, "color");
			layout.Children.Add (nameLabel);
			Label onLabel = new Label () { HorizontalOptions = LayoutOptions.End, TextColor = Color.Blue, Text="On" };
			onLabel.SetBinding (Label.IsVisibleProperty, "isOn");
			Label offLabel = new Label () { HorizontalOptions = LayoutOptions.End, TextColor = Color.Gray, Text="Off" };
			offLabel.SetBinding (Label.IsVisibleProperty, "isNotOn");
			layout.Children.Add (onLabel);
			layout.Children.Add (offLabel);
			View = layout;
		}
	}
}


