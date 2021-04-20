using System;
using Xamarin.Forms;

namespace WorkingWithGestures
{
	public class TapInsideFrame : ContentPage
	{
		int tapCount;
		readonly Label label;

		public TapInsideFrame()
		{
			var frame = new Frame
			{
				OutlineColor = Color.Accent,
				BackgroundColor = Color.Transparent,
				Padding = new Thickness(20, 100),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Content = new Label
				{
					Text = "Tap Inside Frame",
					FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
				}
			};


			var tapGestureRecognizer = 
				new TapGestureRecognizer();
			//tapGestureRecognizer.NumberOfTapsRequired = 2; // double-tap
			tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
			frame.GestureRecognizers.Add(tapGestureRecognizer);


		 	label = new Label
			{
				Text = " ",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Content = new StackLayout
			{
				Children =
				{
					frame,
					label
				}
			};
		}

		void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{
			tapCount++;
			label.Text = String.Format("{0} tap{1} so far!",
				tapCount,
				tapCount == 1 ? "" : "s");
		}
	}
}
