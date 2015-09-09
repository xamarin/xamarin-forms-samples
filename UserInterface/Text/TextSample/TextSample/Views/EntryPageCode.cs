using System;

using Xamarin.Forms;

namespace TextSample
{
	public class EntryPageCode : ContentPage
	{
		public EntryPageCode ()
		{
			var layout = new StackLayout{ Padding = new Thickness (5, 10) };
			this.Title = "Entry Demo - Code";
			layout.Children.Add (new Label{ Text = "This page demonstrates the Entry View. The Entry is used for collecting text that is expected to take one line." });
			layout.Children.Add (new Label{ Text = "Unlike the Editor, the Entry view supports more advance formatting and customization." });
			var scroll = new ScrollView{ VerticalOptions = LayoutOptions.StartAndExpand };
			var secondLayout = new StackLayout ();
			secondLayout.Children.Add (new Entry{ Text = "Xamarin Green", TextColor = Color.FromHex ("#77d065") });
			secondLayout.Children.Add (new Entry{ Placeholder = "Username", BackgroundColor = Color.FromHex ("#2c3e50") });
			secondLayout.Children.Add (new Entry{ Placeholder = "Password", IsPassword = true });
			secondLayout.Children.Add (new Entry{ Text = "Default presentation" });
			secondLayout.Children.Add (new Entry{ Placeholder = "Placeholder text" });
			secondLayout.Children.Add (new Entry{ IsEnabled = false, Text = "This is a disabled entry" });
			secondLayout.Children.Add (new Entry {
				TextColor = Color.FromHex ("#77d065"),
				Text = "This is an entry with a textcolor specified"
			});
			scroll.Content = secondLayout;
			layout.Children.Add (scroll);
			this.Content = layout;
		}
	}
}


