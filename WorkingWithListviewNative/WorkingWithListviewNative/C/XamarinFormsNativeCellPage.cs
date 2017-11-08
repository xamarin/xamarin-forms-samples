using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace WorkingWithListviewNative
{
	/// <summary>
	/// This page uses built-in Xamarin.Forms controls to display a fast-scrolling list.
	///
	/// It uses the built-in <c>TextCell</c> class which does not require special 'layout'
	/// and is therefore faster than building a custom ViewCell in Xamarin.Forms.
	/// </summary>
	public class XamarinFormsNativeCellPage : ContentPage
	{
		public XamarinFormsNativeCellPage ()
		{
			var listView = new ListView ();
			listView.ItemsSource = DataSource.GetList ();
			listView.ItemTemplate = new DataTemplate (typeof(NativeCell));

			listView.ItemTemplate.SetBinding (NativeCell.NameProperty, "Name");
			listView.ItemTemplate.SetBinding (NativeCell.CategoryProperty, "Category");
			listView.ItemTemplate.SetBinding (NativeCell.ImageFilenameProperty, "ImageFilename");

			listView.ItemSelected += async (sender, e) => {
				if (e.SelectedItem == null)
					return;
				listView.SelectedItem = null; // deselect row

				await Navigation.PushModalAsync (new DetailPage (e.SelectedItem));
			};

			Content = new StackLayout {
				Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0),
				Children = {
					new Label {
						HorizontalTextAlignment = TextAlignment.Center,
						Text = "Xamarin.Forms native Cell"
					},
					listView
				}
			};
		}
	}
}
