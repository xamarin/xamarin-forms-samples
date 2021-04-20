using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using MobileCRM.Shared.CustomViews;
using MobileCRMAndroid;
using Android.Widget;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics.Drawables;
using Android.Graphics;

using Color = Xamarin.Forms.Color;
using View = global::Android.Views.View;
using ViewGroup = global::Android.Views.ViewGroup;
using Context = global::Android.Content.Context;
using ListView = global::Android.Widget.ListView;
using Android.App;

[assembly: ExportCell (typeof (DarkTextCell), typeof (DarkTextCellRenderer))]

namespace MobileCRMAndroid
{
    public class DarkTextCellRenderer : ImageCellRenderer
    {
        protected override View GetCellCore (Cell item, View convertView, ViewGroup parent, Context context)
        {
            var cell = (LinearLayout)base.GetCellCore (item, convertView, parent, context);
            cell.SetPadding(20, 30, 0, 30);
            cell.DividerPadding = 50;
        

            var div = new ShapeDrawable();
            div.SetIntrinsicHeight(1);
            div.Paint.Set(new Paint { Color = Color.FromHex("00FFFFFF").ToAndroid() });

            if (parent is ListView) {
                ((ListView)parent).Divider = div;
                ((ListView)parent).DividerHeight = 1;
            }


            var image = (ImageView)cell.GetChildAt(0);
            image.SetScaleType(ImageView.ScaleType.FitCenter);

            image.LayoutParameters.Width = 60;
            image.LayoutParameters.Height = 60;
            

            var linear = (LinearLayout)cell.GetChildAt(1);
            linear.SetGravity(Android.Views.GravityFlags.CenterVertical);

            var label = (TextView)linear.GetChildAt(0);
            label.SetTextColor(Color.White.ToAndroid());
            label.TextSize = Font.SystemFontOfSize(NamedSize.Large).ToScaledPixel();
            label.Gravity = (Android.Views.GravityFlags.CenterVertical);
            var secondaryLabel = (TextView)linear.GetChildAt(1);
            secondaryLabel.Visibility = Android.Views.ViewStates.Gone;


            return cell;
        }
    }
}

