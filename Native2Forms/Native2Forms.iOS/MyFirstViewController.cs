using System;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;

namespace Native2Forms
{
	public class MyFirstViewController : UIViewController
	{
		UIButton button;
		UILabel label;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;

			Title = "Native2Forms";

			label = new UILabel (new CGRect (10, 80, 320, 40));
			label.Text = "This is a native iOS UIKit view";


			button = new UIButton (UIButtonType.System);
			button.Frame = new CGRect (10, 140, 300, 30);
			button.SetTitle ("Click for forms page", UIControlState.Normal);

			button.TouchUpInside += (sender, e) => {
				var secondViewController = App.GetSecondPage().CreateViewController ();
				NavigationController.PushViewController(secondViewController, true);
			};


			View.Add (label);
			View.Add (button);
		}
	}
}

