using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LayoutSamples
{
	public class MonkeyMusicCode : ContentPage
	{

		public MonkeyMusicCode ()
		{
			Title = "Monkey Music - C#";
			var outerLayout = new AbsoluteLayout ();
			var ListOfAlbums = new ListView { SeparatorVisibility = SeparatorVisibility.None, RowHeight = 175 };
			BoxView controlBar = new BoxView { Color = Color.FromHex ("#2c3e50") };
			Button prevButton = new Button {
				BackgroundColor = Color.FromHex ("#3498db"),
				TextColor = Color.White,
				Text = "<",
				BorderRadius = 15,
				HeightRequest = 30,
				WidthRequest = 30
			};
			Button playButton = new Button {
				FontSize = 25,
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.FromHex ("#3498db"),
				TextColor = Color.White,
				Text = "||",
				BorderRadius = 25,
				HeightRequest = 50,
				WidthRequest = 50
			};
			Button nextButton = new Button {
				BackgroundColor = Color.FromHex ("#3498db"),
				TextColor = Color.White,
				Text = ">",
				BorderRadius = 15,
				HeightRequest = 30,
				WidthRequest = 30
			};
			ListOfAlbums.ItemTemplate = new DataTemplate (typeof(listItemTemplate));
			var source = new List<playlist> ();
			source.Add (new playlist{ Name = "Fun Afternoon" });
			source.Add (new playlist{ Name = "Dance Workout" });
			source.Add (new playlist{ Name = "Code 4 Dayz" });
			ListOfAlbums.ItemsSource = source;
			ListOfAlbums.ItemSelected += ListOfAlbums_ItemSelected;
			outerLayout.Children.Add (ListOfAlbums, new Rectangle (0, 0, 1, .95), AbsoluteLayoutFlags.All);
			outerLayout.Children.Add (controlBar, new Rectangle (0, 1, 500, 40), AbsoluteLayoutFlags.PositionProportional);
			outerLayout.Children.Add (prevButton, new Rectangle (.25, 1, 30, 30), AbsoluteLayoutFlags.PositionProportional);
			outerLayout.Children.Add (playButton, new Rectangle (.5, 1, 50, 50), AbsoluteLayoutFlags.PositionProportional);
			outerLayout.Children.Add(nextButton, new Rectangle(.75,1,30,30), AbsoluteLayoutFlags.PositionProportional);
			Content = outerLayout;
		}

		void ListOfAlbums_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}

		public class listItemTemplate : ViewCell{
			public listItemTemplate(){
				var stack = new StackLayout { Padding = new Thickness(15) };
				var albumsLayout = new AbsoluteLayout { Padding = new Thickness(25) };
				albumsLayout.Children.Add(new Image {BackgroundColor = Color.FromHex("#3498db"), Rotation = 30 }, new Rectangle(.5,0,100,100), AbsoluteLayoutFlags.PositionProportional);
				albumsLayout.Children.Add(new Image {BackgroundColor = Color.FromHex("#b455b6"), Rotation = 60 }, new Rectangle(.5,0,100,100), AbsoluteLayoutFlags.PositionProportional);
				albumsLayout.Children.Add(new Image {BackgroundColor = Color.FromHex("#77d065")}, new Rectangle(.5,0,100,100), AbsoluteLayoutFlags.PositionProportional);
				stack.Children.Add(albumsLayout);
				var label = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand};
				stack.Children.Add(label);
				label.SetBinding (Label.TextProperty, "Name");
				this.View = stack;
			}
		}
		public class playlist{
			public string Name { get; set; }
			public string Album1 { get; set; }
			public string Album2 { get; set; }
			public string Album3 { get; set; }
		}
	}
}


