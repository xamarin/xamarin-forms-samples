using System;

using Xamarin.Forms;

namespace TableViewSamples
{
	public class FormIntentCode : ContentPage
	{
		public FormIntentCode ()
		{
			this.Title = "Form Intent";
			var table = new TableView () { Intent = TableIntent.Form };
			var root = new TableRoot ();
			var section1 = new TableSection () {Title = "First Section"};
			var section2 = new TableSection () {Title = "Second Section"};

			var text = new TextCell { Text = "TextCell", Detail = "TextCell Detail" };
			var entry = new EntryCell { Text = "EntryCell Text", Label = "Entry Label" };
			var switchc = new SwitchCell { Text = "SwitchCell Text" };
			var image = new ImageCell { Text = "ImageCell Text", Detail = "ImageCell Detail", ImageSource = "XamarinLogo.png" };

			section1.Add (text); 
			section1.Add (entry);
			section1.Add (switchc);
			section1.Add (image);
			section2.Add (text);
			section2.Add (entry);
			section2.Add (switchc);
			section2.Add (image);
			table.Root = root;
			root.Add (section1);
			root.Add (section2);

			Content = table;
		}
	}
}


