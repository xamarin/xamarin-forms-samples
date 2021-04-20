using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
	/// <summary>
	/// Demonstrates the new ContextActions property introduced in Xamarin.Forms 1.3
	/// </summary>
	public class ContextActionsCell : ViewCell
	{
		public ContextActionsCell ()
		{
			var label1 = new Label { Text = "Label 1", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), FontAttributes = FontAttributes.Bold };
			label1.SetBinding(Label.TextProperty, new Binding("."));
			var hint = Device.RuntimePlatform == Device.iOS ? "Tip: swipe left for context action" : "Tip: long press for context action";
			var label2 = new Label { Text = hint, FontSize=Device.GetNamedSize(NamedSize.Micro, typeof(Label)) };

			//
			// define context actions
			//
			var moreAction = new MenuItem { Text = "More" };
			moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			moreAction.Clicked += (sender, e) => {
				var mi = ((MenuItem)sender);
				Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter);
			};

			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			deleteAction.Clicked += (sender, e) => {
				var mi = ((MenuItem)sender);
				Debug.WriteLine("Delete Context Action clicked: " + mi.CommandParameter);
			};

			//
			// add context actions to the cell
			//
			ContextActions.Add (moreAction);
			ContextActions.Add (deleteAction);



			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (15, 5, 5, 15),
				Children = {
					new StackLayout {
						Orientation = StackOrientation.Vertical,
						Children = { label1, label2 }
					}
				}
			};
		}
	}
}
