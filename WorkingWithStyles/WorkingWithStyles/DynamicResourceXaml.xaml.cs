using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorkingWithStyles
{
	/// <summary>
	/// This page demonstrates the DynamicResource concept
	/// which is used by the Device.Styles to reflect iOS Dynamic Type
	/// </summary>
	public partial class DynamicResourceXaml : ContentPage
	{
		bool continueTimer;

		public DynamicResourceXaml ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			continueTimer = true;
			Device.StartTimer (TimeSpan.FromSeconds (1),
				() => {
					Resources["currentDateTime"] = DateTime.Now.ToString();
					return continueTimer;
				});
			base.OnAppearing ();
		}

		protected override void OnDisappearing ()
		{
			continueTimer = false;
			base.OnDisappearing ();
		}
	}
}

