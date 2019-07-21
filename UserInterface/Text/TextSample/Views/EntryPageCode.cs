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
			layout = new StackLayout { Margin = new Thickness (20) };
			this.Title = "Entry Demo - Code";
			styledEntry.Focused += StyledEntry_Focused;

            var entry = new Entry { Placeholder = "Enter text here", ReturnType = ReturnType.Send };
            entry.Keyboard = Keyboard.Create(KeyboardFlags.Suggestions | KeyboardFlags.CapitalizeCharacter);

			layout.Children.Add (new Entry ());
			layout.Children.Add (styledEntry);
            layout.Children.Add (entry);
            layout.Children.Add(new Entry { Text = "Cursor position and selection length set", CursorPosition = 5, SelectionLength = 10 });
            layout.Children.Add(new Entry { Text = "This is a read-only Entry", IsReadOnly = true });
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
