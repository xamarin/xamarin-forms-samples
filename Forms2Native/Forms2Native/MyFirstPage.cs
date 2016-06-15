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
		Button button1;
		Button button2;

		public MyFirstPage ()
		{
			Title = "My First Xamarin.Forms";

			var label = new Label {
				Text = "Hello native rendering...",
				FontAttributes = FontAttributes.None,
				FontSize = 20
			};

			button1 = new Button { Text = "Click to see a native page" };
			button1.Clicked += (s, e) => Navigation.PushAsync (new MySecondPage ());

			button2 = new Button { Text = GetNativeTitle() };
			button2.Clicked += (s, e) => MessagingCenter.Send(this, App.NativeNavigationMessage, new NativeNavigationArgs(new MyThirdPage()));

			Content = new StackLayout {
				Spacing = 10,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					label,
					button1, button2
				}
			};
		}

		string GetNativeTitle()
		{
			switch (Device.OS) {
				case TargetPlatform.iOS:
					return "Click to see a native UIViewController";

				case TargetPlatform.Android:
					return "Click to see an Intent work";

				default:
					return "Click to see a Windows Phone Page";
			}
		}
	}
}