using System;

using Xamarin.Forms;

namespace ResponsiveLayout
{
	public class AbsoluteLayoutPageCode : ContentPage
	{
		public AbsoluteLayoutPageCode ()
		{
			Title = "AbsoluteLayout - C#";
			BackgroundImage = "deer.jpg";
			var outerLayout = new AbsoluteLayout ();
			var scroll = new ScrollView ();
			outerLayout.Children.Add (scroll, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			outerLayout.Children.Add (new Button {
				Text = "Previous",
				BackgroundColor = Color.White,
				TextColor = Color.Green,
				BorderRadius = 0
			}, new Rectangle (0, 1, .5, 60), AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
			outerLayout.Children.Add (new Button {
				Text = "Next",
				BackgroundColor = Color.White,
				TextColor = Color.Green,
				BorderRadius = 0
			}, new Rectangle (1, 1, .5, 60), AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
			var innerLayout = new AbsoluteLayout ();
			scroll.Content = innerLayout;
			innerLayout.Children.Add (new Image { Source = "deer.jpg" }, new Rectangle (.5, 0, 300, 300), AbsoluteLayoutFlags.PositionProportional);
			innerLayout.Children.Add (new BoxView { Color = Color.FromHex ("#CC1A7019") }, new Rectangle (.5, 300, .7, 50), AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional);
			innerLayout.Children.Add (new Label {
				Text = "deer.jpg",
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor = Color.White
			}, new Rectangle (.5, 310, 1, 50), AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional);
			Content = outerLayout;
		}
	}
}


