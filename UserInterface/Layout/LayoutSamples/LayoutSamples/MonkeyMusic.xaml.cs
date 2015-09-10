using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LayoutSamples
{
	public partial class MonkeyMusic : ContentPage
	{
		private class playlist{
			public string Name { get; set; }
			public string Album1 { get; set; }
			public string Album2 { get; set; }
			public string Album3 { get; set; }
		}

		public MonkeyMusic ()
		{
			InitializeComponent ();
			var source = new List<playlist> ();
			source.Add (new playlist{ Name = "Fun Afternoon" });
			source.Add (new playlist{ Name = "Dance Workout" });
			source.Add (new playlist{ Name = "Code 4 Dayz" });
			ListOfAlbums.ItemsSource = source;
			ListOfAlbums.ItemSelected += ListOfAlbums_ItemSelected;
		}

		void ListOfAlbums_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}

