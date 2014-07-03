using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace EmployeeDirectoryTests
{
	[TestFixture]
	public class SearchTests
	{
		private IApp app;

		private string TextEntryClassName {
			get {
				return app.GetType () == typeof(iOSApp) ? "UITextField" : "EditText";
			}
		}

		[SetUp]
		public void SetUp ()
		{
			app = ConfigureApp.iOS.Debug ().AppBundle ("/Users/olegoid/Projects/xamarin-forms-samples/EmployeeDirectory/EmployeeDirectory.iOS/bin/iPhoneSimulator/Debug/EmployeeDirectoryiOS.app").StartApp ();
			OpenSearchPage ();
		}

		[TearDown]
		public void TearDown ()
		{
			app = null;
		}

		[Test, Category ("SearchFeature")]
		public void SearchByName ()
		{
			string searchRequest = "Miguel";
			string expectedResult = "de Icaza";
			Search (searchRequest);

			Assert.IsTrue (CheckSearchResult (expectedResult), 
				"Search by name doesn't work");
		}

		private void Search (string searchRequest)
		{
			app.EnterText (c => c.Class(TextEntryClassName).Index (0), searchRequest);
		}

		private bool CheckSearchResult (string expectedResult)
		{
			return app.Query (c => c.Raw ("* {text CONTAINS '" + expectedResult + "'}")).Any ();
		}

		private void OpenSearchPage ()
		{
			app.EnterText (c => c.Class(TextEntryClassName).Index (0), "username");
			app.EnterText (c => c.Class(TextEntryClassName).Index (1), "password");
			app.Tap (c => c.Button ("Login"));
			app.Tap (c => c.Button());
		}
	}
}

