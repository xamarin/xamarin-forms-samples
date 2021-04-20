using System;
using Xamarin.QuickUI.Platform.iOS;
using Meetum.Views;
using Xamarin.QuickUI;
using MonoTouch.UIKit;
using Meetum.iOS;
using System.Collections.Generic;

[assembly: ExportCell (typeof (StripedViewCell), typeof (StripedViewCellRenderer))]

namespace Meetum.iOS
{
    public class StripedViewCellRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell (Cell item, UITableView tv)
        {
            var cellView = base.GetCell (item, tv);
            var index = ((List<OptionItem>)((ListView)item.Parent).ItemSource).IndexOf((OptionItem)item.BindingContext);
            cellView.BackgroundColor = index % 2 == 0 ? cellView.BackgroundColor : UIColor.FromRGB(255,255,240);
            return cellView;
        }
    }
}

