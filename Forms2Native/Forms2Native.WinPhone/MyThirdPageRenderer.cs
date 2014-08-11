using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(Forms2Native.MyThirdPage), typeof(Forms2Native.WinPhone.MyThirdPageRenderer))]

namespace Forms2Native.WinPhone
{
    public class MyThirdPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var p = new MyThirdNativePage();
            this.Children.Add(p);
        }      
    }
}
