using CoreGraphics;
using UIKit;
using Xamarin.Forms;

namespace CustomRenderer.iOS
{
	internal class NativeiOSCell : UITableViewCell, INativeElementView
	{
		public UILabel HeadingLabel { get; set; }
		public UILabel SubheadingLabel { get; set; }
		public UIImageView CellImageView { get; set; }

		public NativeCell NativeCell { get; private set; }
		public Element Element => NativeCell;

		public NativeiOSCell(string cellId, NativeCell cell) : base(UITableViewCellStyle.Default, cellId)
		{
			NativeCell = cell;

			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.FromRGB(255, 255, 224);
			CellImageView = new UIImageView();

			HeadingLabel = new UILabel()
			{
				Font = UIFont.FromName("Cochin-BoldItalic", 22f),
				TextColor = UIColor.FromRGB(127, 51, 0),
				BackgroundColor = UIColor.Clear
			};

			SubheadingLabel = new UILabel()
			{
				Font = UIFont.FromName("AmericanTypewriter", 12f),
				TextColor = UIColor.FromRGB(38, 127, 0),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};

			ContentView.Add(HeadingLabel);
			ContentView.Add(SubheadingLabel);
			ContentView.Add(CellImageView);
		}

		public void UpdateCell(NativeCell cell)
		{
			HeadingLabel.Text = cell.Name;
			SubheadingLabel.Text = cell.Category;
			CellImageView.Image = GetImage(cell.ImageFilename);
		}

		public UIImage GetImage(string filename)
		{
			return (!string.IsNullOrWhiteSpace(filename)) ? UIImage.FromFile("Images/" + filename + ".jpg") : null;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			HeadingLabel.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
			SubheadingLabel.Frame = new CGRect(100, 18, 100, 20);
			CellImageView.Frame = new CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
		}
	}
}
