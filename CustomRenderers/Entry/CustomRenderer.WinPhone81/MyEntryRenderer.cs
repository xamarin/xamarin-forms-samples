using CustomRenderer;
using CustomRenderer.WinPhone81;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer (typeof(MyEntry), typeof(MyEntryRenderer))]
namespace CustomRenderer.WinPhone81
{
	public class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.Background = new SolidColorBrush (Colors.Cyan);
			}
		}
	}
}
