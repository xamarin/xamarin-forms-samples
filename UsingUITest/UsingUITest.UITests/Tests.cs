using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UsingUITest.UITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("MyLabel").Text("Hello, Xamarin.Forms!");
		static readonly Func<AppQuery, AppQuery> Button = c => c.Marked("MyButton");
		static readonly Func<AppQuery, AppQuery> DoneMessage = c => c.Marked("MyLabel").Text("Was clicked");


		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void AppLaunches()
		{
#if DEBUG
			// The following method will trap the UI test into REPL tool window CLI
			app.Repl();
			// if you want to quit the REPL tool, type quit at the REPL prompt
#endif
			// Arrange - Nothing to do because the queries have already been initialized.
			AppResult[] result = app.Query(InitialMessage);
			Assert.IsTrue(result.Any(), "The initial message string isn't correct - maybe the app wasn't re-started?");

			// Act
			app.Tap(Button);

			// Assert
			result = app.Query(DoneMessage);
			Assert.IsTrue(result.Any(), "The 'clicked' message is not being displayed.");
		}
	}
}

