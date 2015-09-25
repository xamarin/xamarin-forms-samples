using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class AbsoluteLayoutExplorationCode : ContentPage
	{
		public AbsoluteLayoutExplorationCode ()
		{
			Title = "Absolute Layout Exploration - C#";
			var layout = new AbsoluteLayout();

			var centerLabel = new Label {Text = "I'm centered on iPhone 4 but no other device.", LineBreakMode = LineBreakMode.WordWrap, FontSize = 20};

			AbsoluteLayout.SetLayoutBounds (centerLabel, new Rectangle (115, 159, 100, 100));
			// it is not necessary to set layout flags because absolute positioning is the default

			var bottomLabel = new Label { Text = "I'm bottom center on every device.", LineBreakMode = LineBreakMode.WordWrap };
			AbsoluteLayout.SetLayoutBounds (bottomLabel, new Rectangle (.5, 1, .5, .1));
			AbsoluteLayout.SetLayoutFlags (bottomLabel, AbsoluteLayoutFlags.All);

			var rightBox = new BoxView{ Color = Color.Olive };
			AbsoluteLayout.SetLayoutBounds (rightBox, new Rectangle (1, .5, 25, 100));
			AbsoluteLayout.SetLayoutFlags (rightBox, AbsoluteLayoutFlags.PositionProportional);

			var leftBox = new BoxView{ Color = Color.Red };
			AbsoluteLayout.SetLayoutBounds (leftBox, new Rectangle (0, .5, 25, 100));
			AbsoluteLayout.SetLayoutFlags (leftBox, AbsoluteLayoutFlags.PositionProportional);

			var topBox = new BoxView{ Color = Color.Blue };
			AbsoluteLayout.SetLayoutBounds (topBox, new Rectangle (.5, 0, 100, 25));
			AbsoluteLayout.SetLayoutFlags (topBox, AbsoluteLayoutFlags.PositionProportional);

			layout.Children.Add (bottomLabel);
			layout.Children.Add (centerLabel);
			layout.Children.Add (rightBox);
			layout.Children.Add (leftBox);
			layout.Children.Add (topBox);

			Content = layout;
		}
	}
}


