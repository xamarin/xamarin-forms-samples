using System;
using Xamarin.Forms;

namespace Forms2Native
{
	/// <summary>
	/// This Xamarin.Forms page will actually be rendered natively
	/// on iOS using a custom UIViewController
	/// </summary>
	public class MyThirdPage : ContentPage
	{
		public String Heading;

		public MyThirdPage ()
		{
			Title = "Third Page";

			Heading = "This is the third page";

			// rendering of this page is done natively on each platform, otherwise it will just be blank
		}
	}
}
