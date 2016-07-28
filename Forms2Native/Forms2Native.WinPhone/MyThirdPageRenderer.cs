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
