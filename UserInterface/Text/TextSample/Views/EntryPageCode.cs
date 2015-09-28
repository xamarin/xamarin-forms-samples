 using System;

using Xamarin.Forms;

namespace TextSample
{
	public class EntryPageCode : ContentPage
	{
		Entry styledEntry = new Entry();
		int currentStatus = 0;
		int maxStatus = 4;
		StackLayout layout;
		public EntryPageCode ()
		{
			layout = new StackLayout{ Padding = new Thickness (5, 10) };
			this.Title = "Entry Demo - Code";
			styledEntry.Focused += StyledEntry_Focused;

			layout.Children.Add (new Entry ());
			layout.Children.Add (styledEntry);
			this.Content = layout;
		}

		void StyledEntry_Focused (object sender, FocusEventArgs e)
		{
			if (currentStatus > maxStatus) {
				currentStatus = 0;
			}
			layout.Children.Remove ((Entry)sender);
			switch (currentStatus) {
			case 0:
				styledEntry = new Entry { Placeholder = "Username" };
				break;
			case 1:
				styledEntry = new Entry { Text = "Password", IsPassword = true };
				break;
			case 2:
				styledEntry = new Entry { Placeholder = "Password", IsPassword = true };
				break;
			case 3:
				styledEntry = new Entry { TextColor = Color.FromHex ("#77d065"), Text = "Xamarin Green" };
				break;
			case 4:
				styledEntry = new Entry {
					BackgroundColor = Color.FromHex ("#2c3e50"),
					TextColor = Color.White,
					Text = "White on blue background"
				};
				break;
			}
			styledEntry.Focused += StyledEntry_Focused;
			layout.Children.Add (styledEntry);
			currentStatus++;
		}
	}
}


