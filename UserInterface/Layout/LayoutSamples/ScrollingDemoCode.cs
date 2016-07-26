using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class ScrollingDemoCode : ContentPage
	{
		public ScrollingDemoCode ()
		{
			Title = "ScrollView Demo - C#";
			var scroll = new ScrollView ();
			var label = new Label { Text = "Position" };
			var target = new Entry ();
			var stack = new StackLayout ();
			scroll.Content = stack;
			stack.Children.Add (label);
			stack.Children.Add (new BoxView { BackgroundColor = Color.Red, HeightRequest = 600, WidthRequest = 150 });
			stack.Children.Add (target);
			Content = scroll;
			scroll.ScrollToAsync (target, ScrollToPosition.Center, true);
			scroll.Scrolled+= (object sender, ScrolledEventArgs e) => {
				label.Text = "Position: " + e.ScrollX + " x " + e.ScrollY;
			};
		}
	}
}


