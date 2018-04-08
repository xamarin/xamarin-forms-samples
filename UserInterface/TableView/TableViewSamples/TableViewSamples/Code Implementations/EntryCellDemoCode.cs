using System;

using Xamarin.Forms;

namespace TableViewSamples
{
	public class EntryCellDemoCode : ContentPage
	{
		public EntryCellDemoCode ()
		{
			this.Title = "EntryCell";
			var table = new TableView ();
			var root = new TableRoot ();
			var section1 = new TableSection () {Title="Keyboards" };
			var section2 = new TableSection () { Title = "States & Colors" };

			var entryDefault = new EntryCell { Text = "Default", Placeholder="default" };
			var entryChat = new EntryCell { Text = "Chat", Placeholder="omg brb ttyl gtg lol", Keyboard=Keyboard.Chat };
			var entryEmail = new EntryCell { Text = "Email", Placeholder="sales@xamarin.com", Keyboard=Keyboard.Email };
			var entryNumeric = new EntryCell { Text = "Numeric", Placeholder="55", Keyboard=Keyboard.Numeric };
			var entryTelephone = new EntryCell { Text = "Telephone", Placeholder="+1 012 345 6789", Keyboard=Keyboard.Telephone };
			var entryText = new EntryCell { Text = "Text", Placeholder="text", Keyboard=Keyboard.Text };
			var entryUrl = new EntryCell { Text = "Url", Placeholder="http://developer.xamarin.com", Keyboard=Keyboard.Url };

			var entryColorful = new EntryCell { Text = "Colorful", Placeholder = "text", LabelColor = Color.Red };
			var entryColorfulDisabled = new EntryCell {
				Text = "Colorful + Disabled",
				Placeholder = "text",
				IsEnabled = false,
				LabelColor = Color.Red
			};
			var entryDisabled = new EntryCell{ Text = "Disabled", Placeholder = "text", IsEnabled = false };


			section1.Add (entryDefault); 
			section1.Add (entryChat);
			section1.Add (entryEmail);
			section1.Add (entryNumeric);
			section1.Add (entryTelephone);
			section1.Add (entryText);
			section1.Add (entryUrl);
			section2.Add (entryColorful);
			section2.Add (entryDisabled);
			section2.Add (entryColorfulDisabled);

			Content = table;
		}
	}
}


