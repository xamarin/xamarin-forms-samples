
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Forms2Native
{
	[Activity (Label = "MyThirdActivity")]			
	public class MyThirdActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.MyThirdLayout);

			var button = FindViewById<Button> (Resource.Id.myButton);

			button.Click += (sender, e) => {
				Finish(); // back to the previous activity
			};
		}
	}
}

