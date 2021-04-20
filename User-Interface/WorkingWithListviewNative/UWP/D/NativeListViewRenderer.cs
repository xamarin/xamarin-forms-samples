using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using WorkingWithListviewNative;
using WorkingWithListviewNative.UWP.D;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NativeListView2), typeof(NativeListViewRenderer))]
namespace WorkingWithListviewNative.UWP.D
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
                listView.ItemsSource = ((NativeListView2)e.NewElement).Items;
                listView.ItemTemplate = App.Current.Resources["ListViewItemTemplate"] as Windows.UI.Xaml.DataTemplate;

                // Subscribe
                listView.SelectionChanged += OnSelectedItemChanged;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == NativeListView2.ItemsProperty.PropertyName)
            {
                listView.ItemsSource = ((NativeListView2)Element).Items;
            }
        }

        void OnSelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            ((NativeListView2)Element).NotifyItemSelected(listView.SelectedItem);
        }
    }
}
