using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LayoutSamples
{
	public class AbsoluteLayoutDemoCode : ContentPage
	{
		Label status;
		Label coords;
		Label flagsBounds;
		Button btnPos;
		Button btnSize;
		BoxView anchorVert;
		AbsoluteLayout box;
		AbsoluteLayout absLayout;
		StackLayout layout;

		public AbsoluteLayoutDemoCode ()
		{
			Title = "AbsoluteLayout Demo - C#";
			absLayout = new AbsoluteLayout {
				Padding = new Thickness (0),
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill
			};
			box = new AbsoluteLayout { BackgroundColor = Color.Blue };
			anchorVert = new BoxView {
				BackgroundColor = Color.White,
				WidthRequest = 4,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			box.Children.Add (anchorVert, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.XProportional);
			absLayout.Children.Add (box, new Rectangle (0, 0, .25, .5), AbsoluteLayoutFlags.All);
			this.layout = new StackLayout { Spacing = 10, Padding = new Thickness (20) };
			status = new Label { FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.Black };
			status.Text = "the anchor point of a child is interpolated based on its position\n\n" +
			"the white vertical line represents the X anchor point";
			this.coords = new Label { FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.Black };
			flagsBounds = new Label { FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.Black };
			layout.Children.Add (status);
			layout.Children.Add (coords);
			layout.Children.Add (flagsBounds);
			btnPos = new Button {
				Text = "Position",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Green,
				TextColor = Color.White,
				BorderRadius = 0,
				FontSize = 20
			};
			btnSize = new Button {
				Text = "Size",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Green,
				TextColor = Color.White,
				BorderRadius = 0,
				FontSize = 20
			};

			btnPos.Clicked += HandlePosition;
			btnSize.Clicked += HandleSize;
			absLayout.Children.Add (btnPos, new Rectangle (1, 0, 120, 40), AbsoluteLayoutFlags.PositionProportional);
			absLayout.Children.Add (btnSize, new Rectangle (0, 1, 200, 40), AbsoluteLayoutFlags.PositionProportional);

			absLayout.Children.Add (layout, new Rectangle (.5, .5, .5, .5), AbsoluteLayoutFlags.All);
			Content = absLayout;
		}

		public void HandlePosition (object sender, EventArgs e)
		{
			UpdatePosition ();
		}

		public void HandleSize (object sender, EventArgs e)
		{
			UpdateSize ();
		}

		async void UpdateSize ()
		{
			ToggleEnabled (false);

			float w = 0.0f;
			float h = 0.0f;

			AbsoluteLayout.SetLayoutBounds (box, new Rectangle (0f, 0f, w, h));
			AbsoluteLayout.SetLayoutBounds (anchorVert, new Rectangle (.5, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			while (w <= 1.0) {
				if (Math.Round (w, 2) == 0f) {
					status.Text = "Anchor point is far left";
					await Task.Delay (3000);
				}

				if (Math.Round (w, 2) == 0.5f) {
					status.Text = "Anchor point is in the center";
					await Task.Delay (3000);
				}

				if (Math.Round (w, 2) == 1f) {
					await Task.Delay (3000);
					break;
				}

				w += .01f;
				h += .01f;

				AbsoluteLayout.SetLayoutBounds (box, new Rectangle (0f, 0f, w, h));
				AbsoluteLayout.SetLayoutBounds (anchorVert, new Rectangle (.5, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				flagsBounds.Text = string.Format ("Flags=\"All\" Bounds=\"0, 0, {0}, {1}\"", Math.Round (w, 2), Math.Round (h, 2));

				UpdateLabel ();
				status.Text = " ";

				await Task.Delay (50);
			}

			ToggleEnabled (true);
		}

		async void UpdatePosition ()
		{
			ToggleEnabled (false);

			float x = 0.0f;
			float y = 0.0f;
			AbsoluteLayout.SetLayoutBounds (box, new Rectangle (x, y, .25, .25));
			AbsoluteLayout.SetLayoutBounds (anchorVert, new Rectangle (x, y + (y * box.Height), 5, 5));
			//AbsoluteLayout.SetLayoutBounds(box, new Rectangle(x, y, .25, .25));
			//AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			await Task.Delay (1000);

			while (x <= 1.0) {
				if (Math.Round (x, 2) == 0f) {
					status.Text = "Anchor point is far left";
					await Task.Delay (500);
				}

				if (Math.Round (x, 2) == 0.5f) {
					status.Text = "Anchor point is in the center";
					await Task.Delay (3000);
				}

				if (Math.Round (x, 2) == 1f) {
					status.Text = "Anchor point is far right";
					await Task.Delay (500);
					break;
				}

				x += .01f;
				y += .01f;
				flagsBounds.Text = string.Format ("Flags=\"All\" Bounds=\"{0}, {1}, .25, .25\"", Math.Round (x, 2), Math.Round (y, 2));
				AbsoluteLayout.SetLayoutBounds (box, new Rectangle (x, y, .25, .25));
				AbsoluteLayout.SetLayoutBounds (anchorVert, new Rectangle (x, y + (y * box.Height), 5, 5));

				UpdateLabel ();
				status.Text = " ";

				await Task.Delay (50);
			}

			ToggleEnabled (true);
		}

		void UpdateLabel ()
		{
			var rect = AbsoluteLayout.GetLayoutBounds (box);
			coords.Text = string.Format ("X:{0} x Y:{1}, W:{2} x H:{3}", rect.X.ToString ("0.00"), rect.Y.ToString ("0:00"), Math.Round (rect.Width, 2), Math.Round (rect.Height, 2));
		}

		void ToggleEnabled (bool enabled)
		{
			btnPos.IsEnabled = enabled;
			btnSize.IsEnabled = enabled;
		}
	}
}


