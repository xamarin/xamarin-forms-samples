using System;

using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace WorkingWithListviewNative
{
	/// <summary>
	/// This page uses a custom renderer that wraps native list controls:
	///    iOS :           UITableView
	///    Android :       ListView   (do not confuse with Xamarin.Forms ListView)
	///    Windows Phone : ?
	/// 
	/// It uses a built-in row/cell class provided by the native platform
	/// and is therefore faster than building a custom ViewCell in Xamarin.Forms.
	/// </summary>
	public class NativeListPage : ContentPage
	{
		public NativeListPage ()
		{
			var tableItems = new List<string> ();
			for (var i = 0; i < 100; i++) {
				tableItems.Add (i + " row ");
			}


			var fasterListView = new NativeListView (); // CUSTOM RENDERER using a native control
			fasterListView.VerticalOptions = LayoutOptions.FillAndExpand; // REQUIRED: To share a scrollable view with other views in a StackLayout, it should have a VerticalOptions of FillAndExpand.
			fasterListView.Items = tableItems;
			fasterListView.ItemSelected += async (sender, e) => {
				await Navigation.PushModalAsync (new DetailPage (e.SelectedItem));
			};

			// The root page of your application
			Content = new StackLayout {
				Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0),
				Children = {
					new Label {
						HorizontalTextAlignment = TextAlignment.Center,
						Text = Device.OnPlatform ("Custom renderer UITableView", "Custom renderer ListView", "Custom renderer todo")
					},
					fasterListView 
				}
			};
		}
	}
}