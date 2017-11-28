using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using CustomRenderer;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]

namespace CustomRenderer
{
    class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                Control.BackgroundColor = ElmSharp.Color.FromRgb(204, 153, 255);
            }
        }
    }
}
