using Xamarin.Forms;
using WorkingWithListviewNative;
using WorkingWithListviewNative.Droid;
using Xamarin.Forms.Platform.Android;
using System.Linq;
using Android.Content;

[assembly: ExportRenderer(typeof(NativeListView2), typeof(NativeAndroidListViewRenderer))]

namespace WorkingWithListviewNative.Droid
{
    public class NativeAndroidListViewRenderer : ViewRenderer<NativeListView2, global::Android.Widget.ListView>
    {
        public NativeAndroidListViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<NativeListView2> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new global::Android.Widget.ListView(MainActivity.Instance));
            }

            if (e.OldElement != null)
            {
                // unsubscribe
                Control.ItemClick -= clicked;
            }

            if (e.NewElement != null)
            {
                // subscribe
                Control.Adapter = new NativeAndroidListViewAdapter(MainActivity.Instance as Android.App.Activity, e.NewElement);
                Control.ItemClick += clicked;
            }
        }

        //		public override void Layout (int l, int t, int r, int b)
        //		{
        //			base.Layout (l, t, r, b);
        //		}

        void clicked(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            Element.NotifyItemSelected(Element.Items.ToList()[e.Position]);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == NativeListView.ItemsProperty.PropertyName)
            {
                // update the Items list in the UITableViewSource

                Control.Adapter = new NativeAndroidListViewAdapter(MainActivity.Instance as Android.App.Activity, Element);
            }
        }
    }
}