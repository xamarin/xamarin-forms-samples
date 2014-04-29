using System;
using Xamarin.QuickUI.Platform.Android;
using Xamarin.QuickUI;
using Meetum.Views;
using Meetum.Android;
using Android.Widget;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics.Drawables;
using Android.Graphics;

using Color = Xamarin.QuickUI.Color;
using View = global::Android.Views.View;
using ViewGroup = global::Android.Views.ViewGroup;
using Context = global::Android.Content.Context;
using ListView = global::Android.Widget.ListView;
using Android.App;

[assembly: ExportCell (typeof (DarkTextCell), typeof (DarkTextCellRenderer))]

namespace Meetum.Android
{
    public class DarkTextCellRenderer : TextCellRenderer
    {
        protected override View GetCellCore (Cell item, View convertView, ViewGroup parent, Context context)
        {
            using (var color = new ColorDrawable(Color.FromHex("5AA09B").ToAndroid()))
            {
                ((Activity) context).ActionBar.SetBackgroundDrawable (color);
            }

            var cell = (LinearLayout)base.GetCellCore (item, convertView, parent, context);
            cell.SetPadding(20, 10, 0, 10);
            cell.DividerPadding = 50;

            var div = new ShapeDrawable();
            div.SetIntrinsicHeight(1);
            div.Paint.Set(new Paint { Color = Color.FromHex("AAAAAA").ToAndroid() });

            if (parent is ListView) {
                ((ListView)parent).Divider = div;
                ((ListView)parent).DividerHeight = 1;
            }
            var label = (TextView)((LinearLayout)cell.GetChildAt(1)).GetChildAt(0);
            label.SetTextColor(Color.FromHex("FFFFFF").ToAndroid());
            label.TextSize = Font.SystemFontOfSize(NamedSize.Large).ToScaledPixel();

            var secondaryLabel = (TextView)((LinearLayout)cell.GetChildAt(1)).GetChildAt(1);
            secondaryLabel.SetTextColor(Color.FromHex("AAAAAA").ToAndroid());
            secondaryLabel.TextSize = Font.SystemFontOfSize(NamedSize.Medium).ToScaledPixel();

            return cell;
        }
    }
}

