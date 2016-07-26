using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LayoutSamples
{
	public class RelativeLayoutDemoCode : ContentPage
	{
		Label centerLabel;
		BoxView box;
		AbsoluteLayout outerLayout;
		RelativeLayout layout;
		AbsoluteLayout buttonLayout;
		Button moveButton;
		public float x { get; set; }
		public float y { get; set; }

		public RelativeLayoutDemoCode ()
		{
			Title = "Relative Layout Demo - C#";
			outerLayout = new AbsoluteLayout ();
			layout = new RelativeLayout ();
			centerLabel = new Label { FontSize = 20, Text = "RelativeLayout Demo"};
			buttonLayout = new AbsoluteLayout ();
			box = new BoxView { Color = Color.Blue, HeightRequest = 50, WidthRequest = 50 };
			layout.Children.Add (box, Constraint.RelativeToParent ((parent) => {
				return (parent.Width * .5) - 50;
			}), Constraint.RelativeToParent ((parent) => {
				return (parent.Height * .1) - 50;
			}));
			layout.Children.Add (centerLabel, Constraint.RelativeToParent ((parent) => {
				return (parent.Width * .5) - 50;
			}), Constraint.RelativeToParent ((parent) => {
				return (parent.Height * .5) - 50;
			}));
			moveButton = new Button { BackgroundColor = Color.White, FontSize = 20, TextColor = Color.Lime, Text = "Move", BorderRadius = 0};
			buttonLayout.Children.Add (moveButton, new Rectangle(0,1,1,1), AbsoluteLayoutFlags.All);
			outerLayout.Children.Add (layout, new Rectangle(0,0,1,1), AbsoluteLayoutFlags.All);
			outerLayout.Children.Add (buttonLayout, new Rectangle(0,1,1,50), AbsoluteLayoutFlags.PositionProportional|AbsoluteLayoutFlags.WidthProportional);

			moveButton.Clicked += MoveButton_Clicked;
			x = 0f;
			y = 0f;
			Content = outerLayout;
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


