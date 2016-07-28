using WorkingWithListviewNative;
using WorkingWithListviewNative.WinPhone81.C;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer(typeof(NativeCell), typeof(NativeCellRenderer))]
namespace WorkingWithListviewNative.WinPhone81.C
{
    public class NativeCellRenderer : ViewCellRenderer
    {
        public override Windows.UI.Xaml.DataTemplate GetTemplate(Cell cell)
        {
            return App.Current.Resources["ListViewItemTemplate"] as Windows.UI.Xaml.DataTemplate;
        }
    }
}
