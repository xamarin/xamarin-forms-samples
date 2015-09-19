using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LayoutSamples
{
	public partial class RelativeLayoutDemo : ContentPage
	{
		public float x { get; set; }
		public float y { get; set; }
		public BoxView center;
		public RelativeLayoutDemo()
		{
			InitializeComponent();
			moveButton.Clicked += MoveButton_Clicked;
			x = 0f;
			y = 0f;
			center = new BoxView ();
			/*status.Text = "the anchor point of a child is interpollated based on its position\n\n" +
				"the white vertical line represents the X anchor point";*/
		}

		void MoveButton_Clicked (object sender, EventArgs e)
		{
			UpdatePosition ();
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
			/*ToggleEnabled(false);

			float w = 0.0f;
			float h = 0.0f;

			await box.LayoutTo (new Rectangle (0f, 0f, w, h));
			//AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0f, 0f, w, h));
			await anchorVert.LayoutTo(new Rectangle(new Point(.5,0f), new Size(50,100)));
			//AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(.5, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

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

				box.LayoutTo (new Rectangle (0f, 0f, w, h));
				//AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0f, 0f, w, h));
				anchorVert.LayoutTo(new Rectangle(new Point(.5,0f), new Size(50,100)));
				//AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(.5, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				flagsBounds.Text = string.Format("Flags=\"All\" Bounds=\"0, 0, {0}, {1}\"", Math.Round(w, 2), Math.Round(h, 2));

				UpdateLabel();
				status.Text = " ";

				await Task.Delay(50);
			}

			ToggleEnabled(true);*/
		}

		double max = 10;

		async void UpdatePosition()
		{

			layout.Children.Remove (box);
			layout.Children.Add(box, Constraint.RelativeToParent((parent) =>
				{
					return x;
				}), 
				Constraint.RelativeToParent((parent) =>
					{
						return y ;
					}),
				Constraint.Constant(50), Constraint.Constant(50));


			while(x < 1)
			{
				x += .01f;
				y += .01f;
				centerLabel.Text = String.Format ("{0} x {1}", x, y);
				//flagsBounds.Text = string.Format("Flags=\"All\" Bounds=\"{0}, 0, .25, .25\"", Math.Round(x, 2));
				layout.Children.Remove(box);
				layout.Children.Add(box, Constraint.RelativeToParent((parent) =>
					{
						return (x * parent.Width) - 50;
					}), 
					Constraint.RelativeToParent((parent) =>
					{
							return (y * parent.Height) - 50;
					}),
					Constraint.Constant(50), Constraint.Constant(50));
				await Task.Delay(50);
			}
		}


	}
}

