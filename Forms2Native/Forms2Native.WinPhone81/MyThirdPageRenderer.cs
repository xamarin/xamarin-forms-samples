using Forms2Native;
using Forms2Native.WinPhone81;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer(typeof(MyThirdPage), typeof(MyThirdPageRenderer))]
namespace Forms2Native.WinPhone81
{
    public class MyThirdPageRenderer : PageRenderer
    {
        MyThirdNativePage page;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            page = new MyThirdNativePage();
            this.Children.Add(page);
        }

        protected override Windows.Foundation.Size ArrangeOverride(Windows.Foundation.Size finalSize)
        {
            page.Arrange(new Windows.Foundation.Rect(0, 0, finalSize.Width, finalSize.Height));
            return finalSize;
        }
    }
}
