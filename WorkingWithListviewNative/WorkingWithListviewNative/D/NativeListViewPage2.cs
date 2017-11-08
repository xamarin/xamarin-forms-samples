using Xamarin.Forms;

namespace WorkingWithListviewNative
{
	/// <summary>
	/// This page uses a custom renderer that wraps native list controls:
	///    iOS :           UITableView
	///    Android :       ListView   (do not confuse with Xamarin.Forms ListView)
	///    Windows Phone : ListView
	///
	/// It uses a CUSTOM row/cell class that is defined natively which
	/// is still faster than a Xamarin.Forms-defined ViewCell subclass.
	/// </summary>
	public class NativeListViewPage2 : ContentPage
	{
		public NativeListViewPage2 ()
		{
			var nativeListView2 = new NativeListView2 (); // CUSTOM RENDERER using a native control

			nativeListView2.VerticalOptions = LayoutOptions.FillAndExpand; // REQUIRED: To share a scrollable view with other views in a StackLayout, it should have a VerticalOptions of FillAndExpand.

			nativeListView2.Items = DataSource2.GetList ();

			nativeListView2.ItemSelected += async (sender, e) => {
				//await Navigation.PushModalAsync (new DetailPage(e.SelectedItem));
				await DisplayAlert ("clicked", "one of the rows was clicked", "ok");
			};

			// The root page of your application
			Content = new StackLayout {
				Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0),
				Children = {
					new Label {
						HorizontalTextAlignment = TextAlignment.Center,
						Text = Device.RuntimePlatform == Device.iOS ? "Custom UITableView+UICell" :
									 Device.RuntimePlatform == Device.Android ? "Custom ListView+Cell" : "Custom renderer ListView+DataTemplate"
					},
					nativeListView2
				}
			};
		}
	}
}
