using Xamarin.Forms.Platform.iOS;
using MobileCRM.Shared.CustomViews;
using Xamarin.Forms;
using MonoTouch.UIKit;
using MobileCRM.iOS;

[assembly: ExportCell (typeof (DarkTextCell), typeof (DarkTextCellRenderer))]

namespace MobileCRM.iOS
{

    public class DarkTextCellRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell (Cell item, UITableView tv)
        {
            var cellView = base.GetCell (item, tv);

            tv.SeparatorColor = Color.FromHex("00FFFFFF").ToUIColor();

            return cellView;
        }
    }
    
}
