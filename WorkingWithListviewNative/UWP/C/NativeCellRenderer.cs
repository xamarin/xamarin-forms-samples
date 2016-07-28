using WorkingWithListviewNative;
using WorkingWithListviewNative.UWP.C;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NativeCell), typeof(NativeCellRenderer))]
namespace WorkingWithListviewNative.UWP.C
{
    public class NativeCellRenderer : ViewCellRenderer
    {
        public override Windows.UI.Xaml.DataTemplate GetTemplate(Cell cell)
        {
            return App.Current.Resources["ListViewItemTemplate"] as Windows.UI.Xaml.DataTemplate;
        }
    }
}
