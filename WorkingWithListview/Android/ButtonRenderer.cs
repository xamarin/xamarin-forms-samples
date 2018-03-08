using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using WorkingWithListview.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(Button), typeof(ListButtonRenderer))]
namespace WorkingWithListview.Android
{
    public class ListButtonRenderer : ButtonRenderer
    {
        public ListButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            Control.Focusable = false;
        }
    }
}

