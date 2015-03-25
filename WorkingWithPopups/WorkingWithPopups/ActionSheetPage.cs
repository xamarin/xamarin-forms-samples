using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithPopups
{
	public class ActionSheetPage : ContentPage
	{
		public ActionSheetPage ()
		{
			var label = new Label {
				Text = "DisplayActionSheet",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
			};

			var actionButton1 = new Button { Text = "ActionSheet Simple" };
			actionButton1.Clicked += async (sender, e) => {
				var action = await DisplayActionSheet ("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
				Debug.WriteLine("Action: " + action); // writes the selected button label to the console
			};

			var actionButton2 = new Button { Text = "ActionSheet Cancel/Delete" };
			actionButton2.Clicked += async (sender, e) => {
				var action = await DisplayActionSheet ("ActionSheet: Save Photo?", "Cancel", "Delete", "Photo Roll", "Email");
				Debug.WriteLine("Action: " + action); // writes the selected button label to the console
			};

			// Bug in Android where this list is not scrollable.
//			var actionButton3 = new Button { Text = "ActionSheet Long" };
//			actionButton3.Clicked += async (sender, e) => {
//				var action = await DisplayActionSheet ("ActionSheet: Save Photo?", "Cancel", "Delete"
//					, "Photo Roll"
//					, "Email",
//					 "Option 3", "Option 4", "Option 5", "Option 6",
//					 "Option 7", "Option 8",
//					 "Option 9", "Option 10", "Option 11", "Option 12", "Option 13", "Option 14", "Option 15");
//				Debug.WriteLine("Action: " + action); // writes the selected button label to the console
//			};

			Content = new StackLayout {
				Padding = new Thickness(0,20,0,0),
				Children = {
					label,
					actionButton1,
					actionButton2
				}
			};
		}
	}
}

