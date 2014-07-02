using CustomRenderer;
using CustomRenderer.WinPhone;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]

namespace CustomRenderer.WinPhone
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var nativePhoneTextBox = (PhoneTextBox)Control.Children[0];
                //var nativePasswordBox = (PhoneTextBox)Control.Children[1];
                nativePhoneTextBox.Background = new SolidColorBrush(Colors.Yellow);
            }
        }
    }
}