using System;
using Xamarin.Forms;

namespace CustomRenderer
{
	public class MainPage : ContentPage
	{
		public MainPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label {
						Text = "Hello, Custom Renderer !",
					}, 
					new MyEntry {
						Text = "In Shared Code",
					}
				},
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
		}
	}
}

