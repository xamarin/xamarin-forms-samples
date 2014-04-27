using Xamarin.QuickUI.Platform.iOS;
using Meetum.Views;
using Xamarin.QuickUI;
using MonoTouch.UIKit;
using Meetum.iOS;

[assembly: ExportCell (typeof (DarkTextCell), typeof (DarkTextCellRenderer))]

namespace Meetum.iOS
{

    public class DarkTextCellRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell (Cell item, UITableView tv)
        {
            var cellView = base.GetCell (item, tv);

            cellView.BackgroundColor = Color.Transparent.ToUIColor();
            cellView.TextLabel.TextColor = Color.FromHex("FFFFFF").ToUIColor();
            cellView.DetailTextLabel.TextColor = Color.FromHex("AAAAAA").ToUIColor();

            tv.SeparatorColor = Color.FromHex("444444").ToUIColor();

            return cellView;
        }
    }
    
}
