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
			if (x >= 1) {
				y = 0;
				x = 0;
			}
		}


	}
}

