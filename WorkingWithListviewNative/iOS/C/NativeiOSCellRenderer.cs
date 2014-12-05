using System;
using Xamarin.Forms.Platform.iOS;
using WorkingWithListviewPerf;
using UIKit;
using Xamarin.Forms;
using Foundation;

[assembly: ExportRenderer (typeof (NativeCell), typeof (WorkingWithListviewPerf.iOS.NativeiOSCellRenderer))]


namespace WorkingWithListviewPerf.iOS
{
	public class NativeiOSCellRenderer : ViewCellRenderer
	{
		static NSString rid = new NSString("NativeCell");

		public NativeiOSCellRenderer ()
		{
		}

		public override UIKit.UITableViewCell GetCell (Xamarin.Forms.Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
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

