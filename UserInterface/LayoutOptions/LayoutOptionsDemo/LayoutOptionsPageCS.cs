using Xamarin.Forms;

namespace LayoutOptionsDemo
{
	public class LayoutOptionsPageCS : ContentPage
	{
		StackLayout stackLayout;

		public LayoutOptionsPageCS()
		{
			stackLayout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Spacing = 2,
				Padding = 2,
				BackgroundColor = Color.Gray
			};

			AddButton("Start", LayoutOptions.Start);
			AddButton("Center", LayoutOptions.Center);
			AddButton("End", LayoutOptions.End);
			AddButton("Fill", LayoutOptions.Fill);
			AddButton("StartAndExpand", LayoutOptions.StartAndExpand);
			AddButton("CenterAndExpand", LayoutOptions.CenterAndExpand);
			AddButton("EndAndExpand", LayoutOptions.EndAndExpand);
			AddButton("FillAndExpand", LayoutOptions.FillAndExpand);

			Title = "StackLayout: Start";
			Content = stackLayout;
		}

		void AddButton(string text, LayoutOptions options)
		{
			var button = new Button
			{
				Text = text,
				VerticalOptions = options,
				HeightRequest = Device.OnPlatform(20, 40, 40),
				BackgroundColor = Device.OnPlatform(Color.White, Color.White, Color.Aqua)
			};
			button.Clicked += (sender, e) =>
			{
				Title = "StackLayout: " + text;
				stackLayout.VerticalOptions = options;
			};

			stackLayout.Children.Add(button);
			stackLayout.Children.Add(new BoxView
			{
				BackgroundColor = Color.Yellow,
				HeightRequest = 1
			});
		}
	}
}
