using System;
using Xamarin.Forms;

namespace Forms2Native
{
	/// <summary>
	/// This Xamarin.Forms page will actually be rendered natively
	/// on iOS and Android. There is a Heading property that is set
	/// here which will be accessible when rendering natively.
	/// </summary>
	public class MySecondPage : ContentPage
	{
		public String Heading;

		public MySecondPage ()
		{
			Title = "Second Page";

			Heading = "This is the second page";

			// rendering of this page is done natively on each platform
		}
	}
}
