using System;

using Xamarin.Forms;

namespace ResponsiveLayout
{
	public class RelativeLayoutPageCode : ContentPage
	{
		public RelativeLayoutPageCode ()
		{
			Title = "RelativeLayout - C#";
			BackgroundImage = "deer.jpg";

			var outerLayout = new RelativeLayout ();
			outerLayout.Children.Add (new BoxView { BackgroundColor = Color.FromHex ("#AA1A7019") }, Constraint.RelativeToParent ((parent) => {
				return 0;
			}), Constraint.RelativeToParent ((parent) => {
				return 0;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Width;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Height;
			}));

			var scrollView = new ScrollView ();

			outerLayout.Children.Add (scrollView, Constraint.RelativeToParent ((parent) => {
				return 0;
			}), Constraint.RelativeToParent ((parent) => {
				return 0;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Width;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Height - 60;
			}));

			var innerLayout = new RelativeLayout ();
			scrollView.Content = innerLayout;
			var imageDeer = new Image { Source = "deer.jpg" };
			innerLayout.Children.Add (imageDeer, Constraint.RelativeToParent ((parent) => {
				return parent.Width * .1;
			}), Constraint.RelativeToParent ((parent) => {
				return 10;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Width * .8;
			}), null);

			innerLayout.Children.Add (new Label { Text = "deer,jpg", HorizontalTextAlignment = TextAlignment.Center }, Constraint.RelativeToParent ((parent) => {
				return 0;
			}), Constraint.RelativeToView (imageDeer, ((parent, sibling) => {
				return sibling.Height + 20;
			})), Constraint.RelativeToParent ((parent) => {
				return parent.Width;
			}), Constraint.RelativeToParent ((parent) => {
				return 75;
			}));

			outerLayout.Children.Add (new Button {
				Text = "Previous",
				BackgroundColor = Color.White,
				TextColor = Color.Green,
				BorderRadius = 0
			}, Constraint.RelativeToParent ((parent) => {
				return 0;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Height - 60;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Width * .5;
			}), Constraint.RelativeToParent ((parent) => {
				return 60;
			}));
			outerLayout.Children.Add (new Button {
				Text = "Next",
				BackgroundColor = Color.White,
				TextColor = Color.Green,
				BorderRadius = 0
			}, Constraint.RelativeToParent ((parent) => {
				return parent.Width * .5;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Height - 60;
			}), Constraint.RelativeToParent ((parent) => {
				return parent.Width * .5;
			}), Constraint.RelativeToParent ((parent) => {
				return 60;
			}));
			Content = outerLayout;
		}
	}
}


