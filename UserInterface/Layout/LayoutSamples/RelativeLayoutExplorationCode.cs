using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class RelativeLayoutExplorationCode : ContentPage
	{
		public RelativeLayoutExplorationCode ()
		{
			RelativeLayout layout = new RelativeLayout { HeightRequest = 50, WidthRequest = 50 };
			var blueBox = new BoxView { Color = Color.Blue, HeightRequest = 50, WidthRequest = 50 };
			var redBox = new BoxView { Color = Color.Red, HeightRequest = 50, WidthRequest = 50 };
			var purpleBox = new BoxView { Color = Color.Purple };
			var greenBox = new BoxView { Color = Color.Green, WidthRequest = 50, HeightRequest = 50 };
			var yellowBox = new BoxView { Color = Color.Yellow, WidthRequest = 50, HeightRequest = -50 };
			var grayBox = new BoxView { Color = Color.Gray, WidthRequest = 15 };
			var greenBox2 = new BoxView { Color = Color.Green };

			layout.Children.Add (blueBox, Constraint.RelativeToParent ((parent) => {
				return 0;
			}), Constraint.RelativeToParent ((parent) => {
				return 0;
			}));
			layout.Children.Add (redBox, Constraint.RelativeToParent ((parent) => {
				return parent.Width * .9;
			}), Constraint.RelativeToParent ((parent) => {
				return 0;
			}));
			layout.Children.Add (purpleBox, Constraint.RelativeToParent ((parent) => {
				return parent.Width * .25;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Height * .25;
			}), Constraint.RelativeToParent((parent) => {
				return parent.Width * .5;
			}), Constraint.RelativeToParent((parent) => {
				return parent.Height * .5;
			}));
			layout.Children.Add (greenBox, Constraint.RelativeToParent ((parent) => {
				return 0;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Height * .9;
			}));
			layout.Children.Add (yellowBox, Constraint.RelativeToParent ((parent) => {
				return parent.Width * .9;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Height;
			}));
			layout.Children.Add (grayBox, Constraint.RelativeToParent ((parent) => {
				return parent.Width * .45;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Height * .25;
			}), null, Constraint.RelativeToParent((parent) => {
				return parent.Height * .75;
			}));

			layout.Children.Add (greenBox2, Constraint.RelativeToView (grayBox, (Parent, sibling) => {
				return (sibling.X ) + 15;
			}), Constraint.RelativeToView (grayBox, (parent, sibling) => {
				return sibling.Y;
			}), Constraint.RelativeToParent((parent) => {
				return (parent.Width * .2) + 20;
			}), Constraint.RelativeToParent((parent) => {
				return (parent.Height * .1)+10;
			}));

			Content = layout;
			Title = "RelativeLayout Exploration - C#";
		}
	}
}


