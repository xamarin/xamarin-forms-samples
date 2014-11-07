using System;
using Xamarin.Forms;
using UsingResxLocalization.Resx;

namespace UsingResxLocalization
{
	public class FirstPage : ContentPage
	{
		public FirstPage ()
		{
			var myLabel = new Label();
			var myEntry = new Entry();
			var myButton = new Button();

			myLabel.Text = AppResources.NotesLabel;
			myEntry.Placeholder = AppResources.NotesPlaceholder;
			myButton.Text = AppResources.AddButton;


			var flag = new Image ();
			flag.Source = ImageSource.FromFile ("flag.png");

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {myLabel, myEntry, myButton, flag},
			};
		}
	}
}

