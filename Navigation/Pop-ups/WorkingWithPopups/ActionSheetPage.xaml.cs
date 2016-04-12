using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace WorkingWithPopups
{
	public partial class ActionSheetPage : ContentPage
	{
		public ActionSheetPage ()
		{
			InitializeComponent ();
		}

		async void OnActionSheetSimpleClicked (object sender, EventArgs e)
		{
			var action = await DisplayActionSheet ("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
			Debug.WriteLine ("Action: " + action);
		}

		async void OnActionSheetCancelDeleteClicked (object sender, EventArgs e)
		{
			var action = await DisplayActionSheet ("ActionSheet: SavePhoto?", "Cancel", "Delete", "Photo Roll", "Email");
			Debug.WriteLine ("Action: " + action);
		}
	}
}
