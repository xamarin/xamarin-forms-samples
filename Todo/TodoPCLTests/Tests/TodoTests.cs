using System;
using Xamarin.UITest;
using NUnit.Framework;

namespace TodoPCLTests
{
	public class TodoTests : BaseTest
	{
		public TodoTests(Platform platform) : base(platform)
		{
		}

		public override void BeforeEachTest()
		{
			base.BeforeEachTest();
		}

		[Test]
		public void AddItemtoTodoList()
		{
			ListPage.TapAddButton();
		}
	}
}
