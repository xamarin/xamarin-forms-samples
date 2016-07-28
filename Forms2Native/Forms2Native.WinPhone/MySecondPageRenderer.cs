using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(Forms2Native.MySecondPage), typeof(Forms2Native.WinPhone.MySecondPageRenderer))]


namespace Forms2Native.WinPhone
{
    public class MySecondPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);

            var page = e.NewElement as MySecondPage;

            var stkpanel = new System.Windows.Controls.StackPanel();
            stkpanel.Orientation = System.Windows.Controls.Orientation.Horizontal;

            var label = new System.Windows.Controls.TextBlock
            {
                Text = "2" + page.Heading
            };

            stkpanel.Children.Add(label);

            this.Children.Add(stkpanel);
        }
    }
}
