using System;

using Xamarin.Forms;

namespace UsingUITest
{

	public class MyPage : ContentPage
	{
		Label l;

		public MyPage ()
		{
			var b = new Button {
				Text = "Click me",
				AutomationId = "MyButton"		// referenced in UITests
			};
			b.Clicked += (sender, e) => {
				l.Text = "Was clicked";
			};

			l = new Label { 
				Text = "Hello, Xamarin.Forms!",
				AutomationId = "MyLabel"			// referenced in UITests
			};

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					b, l
				}
			};
		}
	}

	/// <summary>
	/// Demo of setting control identifiers to use with Calabash for testing
	/// https://developer.xamarin.com/guides/xamarin-forms/deployment,_testing,_and_metrics/uitest-and-test-cloud/
	/// </summary>
	public class App : Application
	{
		public App ()
		{	
			MainPage = new MyPage ();
		}
	}

}

