using System;

// forums question
// http://forums.xamarin.com/discussion/17278/custom-font-in-xamarin-forms-font-awesome#latest

// custom fonts in iOS
// http://blog.xamarin.com/custom-fonts-in-ios/

// font download
// http://www.dafont.com/hollywood-hills.font
using Xamarin.Forms;

namespace WorkingWithFonts
{
	public class FontPageCs : ContentPage
	{
		public FontPageCs ()
		{
			var label = new Label {
				Text = "Hello, Forms!",
				Font = Device.OnPlatform (
					Font.OfSize ("SF Hollywood Hills", 24),
					Font.SystemFontOfSize (NamedSize.Medium),
					Font.SystemFontOfSize (NamedSize.Large)
				),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

			};

			var myLabel = new MyLabel {
				Text = "MyLabel for Android!",
				Font = Device.OnPlatform (
					Font.SystemFontOfSize (NamedSize.Small),
					Font.SystemFontOfSize (NamedSize.Medium), // will get overridden in custom Renderer
					Font.SystemFontOfSize (NamedSize.Large)
				),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			var labelBold = new Label {
				Text = "Bold",
				Font = Font.SystemFontOfSize (14, FontAttributes.Bold),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			var labelItalic = new Label {
				Text = "Italic",
				Font = Font.SystemFontOfSize (14, FontAttributes.Italic),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			var labelBoldItalic = new Label {
				Text = "BoldItalic",
				Font = Font.SystemFontOfSize (14, FontAttributes.Bold | FontAttributes.Italic),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					label, myLabel, labelBold, labelItalic, labelBoldItalic
				}
			};
		}
	}
}

