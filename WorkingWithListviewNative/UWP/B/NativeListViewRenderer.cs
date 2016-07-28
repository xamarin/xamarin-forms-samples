using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using WorkingWithListviewNative;
using WorkingWithListviewNative.UWP.B;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NativeListView), typeof(NativeListViewRenderer))]
namespace WorkingWithListviewNative.UWP.B
{
    public class NativeListViewRenderer : ListViewRenderer
    {
        ListView listView;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            listView = Control as ListView;

            if (e.OldElement != null)
            {
                // Unsubscribe
                listView.SelectionChanged -= OnSelectedItemChanged;
            }
            if (e.NewElement != null)
            {
                listView.SelectionMode = ListViewSelectionMode.Single;
                listView.IsItemClickEnabled = false;
                listView.ItemsSource = ((NativeListView)e.NewElement).Items;

                // Subscribe
                listView.SelectionChanged += OnSelectedItemChanged;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == NativeListView.ItemsProperty.PropertyName)
            {
                listView.ItemsSource = ((NativeListView)Element).Items;
            }
        }

        void OnSelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            ((NativeListView)Element).NotifyItemSelected(listView.SelectedItem);
        }
    }
}
