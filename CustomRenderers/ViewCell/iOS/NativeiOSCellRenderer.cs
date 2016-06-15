using CustomRenderer;
using CustomRenderer.iOS;
using Foundation;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(NativeCell), typeof(NativeiOSCellRenderer))]
namespace CustomRenderer.iOS
{
	public class NativeiOSCellRenderer : ViewCellRenderer
	{
		static NSString rid = new NSString ("NativeCell");

		public override UITableViewCell GetCell (Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var x = (NativeCell)item;
			Console.WriteLine (x);

			NativeiOSCell c = reusableCell as NativeiOSCell;

			if (c == null) {
				c = new NativeiOSCell (rid);
			}

			UIImage i = null;
			if (!String.IsNullOrWhiteSpace (x.ImageFilename)) {
				i = UIImage.FromFile ("Images/" + x.ImageFilename + ".jpg");
			}
			c.UpdateCell (x.Name, x.Category, i);

			return c;
		}
	}
}
