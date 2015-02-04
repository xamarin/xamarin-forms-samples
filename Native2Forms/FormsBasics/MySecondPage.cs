using System;
using Xamarin.Forms;

namespace Native2Forms
{
	/// <summary>
	/// This Xamarin.Forms page will be opened from within a 'native' app on iOS and Android
	/// </summary>
	public class MySecondPage : ContentPage
	{
		public MySecondPage ()
		{
			var label = new Label {
				Text = "This is the Xamarin.Forms page",
				Font = Font.SystemFontOfSize (36),
			};

			Content = new StackLayout {
				Spacing = 30,
				VerticalOptions = LayoutOptions.Start,
				Children = {
					label,
				}
			};
		}
	}
}
