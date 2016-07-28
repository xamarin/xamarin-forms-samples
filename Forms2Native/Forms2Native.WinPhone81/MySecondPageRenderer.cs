using Forms2Native;
using Forms2Native.WinPhone81;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer(typeof(MySecondPage), typeof(MySecondPageRenderer))]
namespace Forms2Native.WinPhone81
{
    public  class MySecondPageRenderer : PageRenderer
    {
        Windows.UI.Xaml.Controls.StackPanel stackPanel;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var page = e.NewElement as MySecondPage;

            stackPanel = new Windows.UI.Xaml.Controls.StackPanel();
            stackPanel.Orientation = Windows.UI.Xaml.Controls.Orientation.Horizontal;

            var label = new Windows.UI.Xaml.Controls.TextBlock
            {
                Text = "2" + page.Heading
            };

            stackPanel.Children.Add(label);
            this.Children.Add(stackPanel);
        }

        protected override Windows.Foundation.Size ArrangeOverride(Windows.Foundation.Size finalSize)
        {
            stackPanel.Arrange(new Windows.Foundation.Rect(0, 0, finalSize.Width, finalSize.Height));
            return finalSize;
        }
    }
}

