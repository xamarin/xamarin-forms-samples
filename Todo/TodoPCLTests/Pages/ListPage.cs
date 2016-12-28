using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace TodoPCLTests
{
	public class ListPage : BasePage
	{
		//Initialize variables for elements on page
		protected readonly Query AddButton;

		//Constructor
		public ListPage(IApp app, Platform platform) : base(app, platform)
		{
			AddButton = x => x.Marked("Add");
		}

		public void TapAddButton()
		{
			app.Tap(AddButton);
		}
	}
}