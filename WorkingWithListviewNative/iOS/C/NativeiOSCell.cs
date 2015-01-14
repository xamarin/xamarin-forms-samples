using System;
using UIKit;
using Foundation;

namespace WorkingWithListviewNative.iOS
{
	/// <summary>
	/// Sample of a custom cell layout, taken from the iOS docs at
	/// http://developer.xamarin.com/guides/ios/user_interface/tables/part_3_-_customizing_a_table's_appearance/
	/// </summary>
	public class NativeiOSCell : UITableViewCell  {

		UILabel headingLabel, subheadingLabel;
		UIImageView imageView;

		public NativeiOSCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			ContentView.BackgroundColor = UIColor.FromRGB (255,255,224);

			imageView = new UIImageView();

			headingLabel = new UILabel () {
				Font = UIFont.FromName("Cochin-BoldItalic", 22f),
				TextColor = UIColor.FromRGB (127, 51, 0),
				BackgroundColor = UIColor.Clear
			};

			subheadingLabel = new UILabel () {
				Font = UIFont.FromName("AmericanTypewriter", 12f),
				TextColor = UIColor.FromRGB (38, 127, 0),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};

			ContentView.Add (headingLabel);
			ContentView.Add (subheadingLabel);
			ContentView.Add (imageView);
		}

		public void UpdateCell (string caption, string subtitle, UIImage image)
		{
			imageView.Image = image;
			headingLabel.Text = caption;
			subheadingLabel.Text = subtitle;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			imageView.Frame = new CoreGraphics.CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
			headingLabel.Frame = new CoreGraphics.CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
			subheadingLabel.Frame = new CoreGraphics.CGRect(100, 18, 100, 20);
		}
	}
}

