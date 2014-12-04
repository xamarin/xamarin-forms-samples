using Xamarin.Forms.Platform.iOS;
using MobileCRM.Shared.CustomViews;
using Xamarin.Forms;
using UIKit;
using MobileCRM.iOS;

[assembly: ExportCell (typeof (DarkTextCell), typeof (DarkTextCellRenderer))]

namespace MobileCRM.iOS
{

    public class DarkTextCellRenderer : ImageCellRenderer
    {
		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cellView = base.GetCell (item, reusableCell, tv);

            cellView.BackgroundColor = Color.Transparent.ToUIColor();
            cellView.TextLabel.TextColor = Color.FromHex("FFFFFF").ToUIColor();
            cellView.DetailTextLabel.TextColor = Color.FromHex("AAAAAA").ToUIColor();

            tv.SeparatorColor = Color.FromHex("444444").ToUIColor();

            return cellView;
        }
    }
    
}
