using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Forms2Native
{
	/// <summary>
	/// This is a Xamarin.Forms screen - the first one shown in the app
	/// </summary>
	public class MyFirstPage : ContentPage
	{
		Button button1, button2;
		public MyFirstPage ()
		{
			Title = "My First Xamarin.Forms";

			var label = new Label {
				Text = "Hello native rendering...",
				Font = Font.SystemFontOfSize (20),
			};

			var button1 = new Button { Text = "Click to see a native page" };

			button1.Clicked += (s, e) => Navigation.PushAsync(new MySecondPage());

			if (Device.OS == TargetPlatform.iOS) {
				button2 = new Button { Text = "Click to see a native UIViewController" };
			} else if (Device.OS == TargetPlatform.Android) {
				button2 = new Button { Text = "Click to see an Intent work" };
			} else {
                button2 = new Button { Text = "Click to see a Windows Phone Page" };
            }
			button2.Clicked += (s, e) => Navigation.PushAsync(new MyThirdPage());
			
			Content = new StackLayout {
				Spacing = 10,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					label,
					button1, button2
				}
			};
		}
	}
}
	