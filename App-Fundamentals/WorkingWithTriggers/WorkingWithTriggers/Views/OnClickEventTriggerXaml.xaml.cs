using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorkingWithTriggers
{
	public partial class OnClickEventTriggerXaml : ContentPage
	{
		public OnClickEventTriggerXaml ()
		{
			InitializeComponent ();
		}

		async void OnDoThisClick (object sender, EventArgs ea) 
		{
			await DisplayAlert ("Do this", "alert displays as well as TriggerAction", "Cool");
		}

		async void OnDoThatClick (object sender, EventArgs ea) 
		{
			await DisplayAlert ("Do that", "alert displays as well as TriggerAction", "Cool");
		}
	}
}

