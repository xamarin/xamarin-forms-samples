using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LayoutSamples
{
	public partial class AbsoluteLayoutDemoXaml : ContentPage
	{
		public AbsoluteLayoutDemoXaml()
		{
			InitializeComponent();
			status.Text = "the anchor point of a child is interpolated based on its position\n\n" +
				"the white vertical line represents the X anchor point";
		}

		public void HandlePosition(object sender, EventArgs e)
		{
			UpdatePosition();
		}

		public void HandleSize(object sender, EventArgs e)
		{
			UpdateSize();
		}

		async void UpdateSize()
		{
			ToggleEnabled(false);

			float w = 0.0f;
			float h = 0.0f;

			AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0f, 0f, w, h));
			AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(.5, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			while(w <= 1.0)
			{
				if(Math.Round(w, 2) == 0f)
				{
					status.Text = "Anchor point is far left";
					await Task.Delay(3000);
				}

				if(Math.Round(w, 2) == 0.5f)
				{
					status.Text = "Anchor point is in the center";
					await Task.Delay(3000);
				}

				if(Math.Round(w, 2) == 1f)
				{
					await Task.Delay(3000);
					break;
				}

				w += .01f;
				h += .01f;

				AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0f, 0f, w, h));
				AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(.5, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				flagsBounds.Text = string.Format("Flags=\"All\" Bounds=\"0, 0, {0}, {1}\"", Math.Round(w, 2), Math.Round(h, 2));

				UpdateLabel();
				status.Text = " ";

				await Task.Delay(50);
			}

			ToggleEnabled(true);
		}

		async void UpdatePosition()
		{
			ToggleEnabled(false);

			float x = 0.0f;
			float y = 0.0f;
			AbsoluteLayout.SetLayoutBounds(box, new Rectangle(x, y, .25, .25));
			AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(x, y + (y * box.Height), 5, 5));
			//AbsoluteLayout.SetLayoutBounds(box, new Rectangle(x, y, .25, .25));
			//AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			await Task.Delay(1000);

			while(x <= 1.0)
			{
				if(Math.Round(x, 2) == 0f)
				{
					status.Text = "Anchor point is far left";
					await Task.Delay(500);
				}

				if(Math.Round(x, 2) == 0.5f)
				{
					status.Text = "Anchor point is in the center";
					await Task.Delay(3000);
				}

				if(Math.Round(x, 2) == 1f)
				{
					status.Text = "Anchor point is far right";
					await Task.Delay(500);
					break;
				}

				x += .01f;
				y += .01f;
				flagsBounds.Text = string.Format("Flags=\"All\" Bounds=\"{0}, {1}, .25, .25\"", Math.Round(x, 2), Math.Round(y,2));
				AbsoluteLayout.SetLayoutBounds(box, new Rectangle(x, y, .25, .25));
				AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(x, y + (y * box.Height), 5, 5));

				UpdateLabel();
				status.Text = " ";

				await Task.Delay(50);
			}

			ToggleEnabled(true);
		}

		void UpdateLabel()
		{
			var rect = AbsoluteLayout.GetLayoutBounds(box);
			coords.Text = string.Format("X:{0} x Y:{1}, W:{2} x H:{3}", rect.X.ToString("0.00"), rect.Y.ToString("0:00"), Math.Round(rect.Width, 2), Math.Round(rect.Height, 2));
		}

		void ToggleEnabled(bool enabled)
		{
			btnPos.IsEnabled = enabled;
			btnSize.IsEnabled = enabled;
		}
	}
}

