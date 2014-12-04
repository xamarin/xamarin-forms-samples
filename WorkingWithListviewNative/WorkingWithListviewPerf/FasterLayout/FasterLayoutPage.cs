using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace WorkingWithListviewPerf
{

	/// <summary>
	/// This page uses a custom renderer that wraps native list controls:
	///    iOS :           UITableView
	///    Android :       ListView   (do not confuse with Xamarin.Forms ListView)
	///    Windows Phone : ?
	/// 
	/// It uses a CUSTOM row/cell class that is defined natively which 
	/// is still faster than a Xamarin.Forms-defined ViewCell subclass.
	/// </summary>
	public class FasterLayoutPage : ContentPage
	{
		public FasterLayoutPage ()
		{
			var fasterLayoutListView = new FasterLayoutListView (); // CUSTOM RENDERER using a native control

			fasterLayoutListView.VerticalOptions = LayoutOptions.FillAndExpand; // REQUIRED: To share a scrollable view with other views in a StackLayout, it should have a VerticalOptions of FillAndExpand.

			fasterLayoutListView.Items = DataSource.GetList ();

			fasterLayoutListView.ItemSelected += async (sender, e) => {
				//await Navigation.PushModalAsync (new DetailPage(e.SelectedItem));
				await DisplayAlert ("clicked", "one of the rows was clicked", "ok");
			};

			// The root page of your application
			Content = new StackLayout {
				Padding = new Thickness (0, Device.OnPlatform(20,0,0), 0, 0),
				Children = {
					new Label {
						XAlign = TextAlignment.Center,
						Text = Device.OnPlatform("Custom UITableView+UICell","Custom ListView+Cell","Custom renderer todo")
					},
					fasterLayoutListView
				}
			};
		}
	}
}


