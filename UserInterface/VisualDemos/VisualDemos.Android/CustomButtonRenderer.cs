using Android.Content;
using VisualDemos;
using VisualDemos.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer), new[] { typeof(CustomVisual) })]
namespace VisualDemos.Droid
{
    public class CustomButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Cleanup
            }

            if (e.NewElement != null)
            {
                Control.SetShadowLayer(5, 3, 3, Color.Black.ToAndroid()); 
            }
        }
    }
}
