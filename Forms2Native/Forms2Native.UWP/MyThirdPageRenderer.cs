using Forms2Native;
using Forms2Native.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MyThirdPage), typeof(MyThirdPageRenderer))]
namespace Forms2Native.UWP
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
