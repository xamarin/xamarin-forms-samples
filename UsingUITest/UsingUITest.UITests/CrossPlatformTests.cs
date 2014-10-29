using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Linq;

namespace UsingUITest.UITests
{
	public class CrossPlatformTests
	{
		protected IApp _app;

		static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("MyLabel").Text("Hello, Xamarin.Forms!");

		static readonly Func<AppQuery, AppQuery> Button = c => c.Marked("MyButton");
		static readonly Func<AppQuery, AppQuery> DoneMessage = c => c.Marked("MyLabel").Text("Was clicked");

		/// <summary>
		/// We do 'Ignore' in the base class so that these set of tests aren't actually *run*
		/// outside the context of one of the platform-specific bootstrapper sub-classes.
		/// </summary>
		[SetUp]
		public virtual void SetUp()
		{
			Assert.Ignore ("This class requires a platform-specific bootstrapper to override the `SetUp` method");
		}


		//
		// All the tests go here:
		//


		[Test ()]
		public void TestCase ()
		{
			// Arrange - Nothing to do because the queries have already been initialized.
			AppResult[] result = _app.Query(InitialMessage);
			Assert.IsTrue(result.Any(), "The initial message string isn't correct - maybe the app wasn't re-started?");

			// Act
			_app.Tap(Button);

			// Assert
			result = _app.Query(DoneMessage);
			Assert.IsTrue(result.Any(), "The 'clicked' message is not being displayed.");
		}
	}
}

