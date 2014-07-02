using System;
using Xamarin.Forms;

namespace WorkingWithFonts
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			// forums question
			// http://forums.xamarin.com/discussion/17278/custom-font-in-xamarin-forms-font-awesome#latest

			// custom fonts in iOS
			// http://blog.xamarin.com/custom-fonts-in-ios/

			// font download
			// http://www.dafont.com/hollywood-hills.font
			return new ContentPage { 
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Children = {
						new Label {
							Text = "Hello, Forms!",
							Font = Device.OnPlatform (
								Font.OfSize ("SF Hollywood Hills", 24),
								Font.SystemFontOfSize (NamedSize.Medium),
								Font.SystemFontOfSize (NamedSize.Large)
							),
							VerticalOptions = LayoutOptions.CenterAndExpand,
							HorizontalOptions = LayoutOptions.CenterAndExpand,

						}, new MyLabel {
							Text = "MyLabel for Android!",
							Font = Device.OnPlatform (
								Font.SystemFontOfSize (NamedSize.Small),
								Font.SystemFontOfSize (NamedSize.Medium), // will get overridden in custom Renderer
								Font.SystemFontOfSize (NamedSize.Large)
							),
							VerticalOptions = LayoutOptions.CenterAndExpand,
							HorizontalOptions = LayoutOptions.CenterAndExpand,
						},
					}
				}
			};
		}
	}
}

