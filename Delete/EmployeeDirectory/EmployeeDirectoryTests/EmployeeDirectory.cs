using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace EmployeeDirectoryTests
{
	[TestFixture, Category ("GridLayoutDemoForms")]
	public class EmployeeDirectory
	{
		private IApp app;

		private bool IsAuthenticatedSuccessfully {
			get {
				return app.GetType () == typeof(iOSApp) ? app.Query (c => c.Text ("Favorites")).Any () : 
					app.Query (c => c.Class ("com.android.internal.widget.ActionBarView")).Any ();
			}
		}

		private string TextEntryClassName {
			get {
				return app.GetType () == typeof(iOSApp) ? "UITextField" : "EditText";
			}
		}

		private string SwitchClassName {
			get {
				return app.GetType () == typeof(iOSApp) ? "UISwitch" : "android.widget.Switch";
			}
		}

		private bool LoginDialogAppeared {
			get {
				return app.Query(c => c.Text ("Please enter a username.")).Any();
			}
		}

		private bool PasswordDialogAppeared {
			get {
				return app.Query(c => c.Text ("Please enter a password.")).Any();
			}
		}

		private bool HelpDialogAppeared {
			get {
				return app.Query(c => c.Text ("Enter any username and password")).Any();
			}
		}

		[SetUp]
		public void SetUp ()
		{
			app = ConfigureApp.Android.Debug ().ApkFile ("/Users/olegoid/Projects/xamarin-forms-samples/EmployeeDirectory/EmployeeDirectory.Android/bin/Release/EmployeeDirectory.Android-Signed.apk").StartApp ();
			//app = XQAUITest.CIHelper.UniversalSetup ();
		}

		[TearDown]
		public void TearDown ()
		{
			//XQAUITest.CIHelper.UniversalTearDown (app);
		}

		[Test, Category ("LoginFeature")]
		public void LoginWithValidNameAndPassword ()
		{
			Authenticate ("username", "password");
			Assert.IsTrue (IsAuthenticatedSuccessfully, 
				"Authenticatoin error occured");
		}

		[Test, Category ("LoginFeature")]
		public void LoginWithInvalidUsername ()
		{
			Authenticate (string.Empty, "password");
			Assert.IsTrue (LoginDialogAppeared, 
				"Timed out waiting for username error dialog");

			Assert.IsFalse (IsAuthenticatedSuccessfully, 
				"Authenticatoin error occured");
		}

		[Test, Category ("LoginFeature")]
		public void LoginWithInvalidPassword ()
		{
			Authenticate ("username", string.Empty);
			Assert.IsTrue (PasswordDialogAppeared, 
				"Timed out waiting for password error dialog");

			Assert.IsFalse (IsAuthenticatedSuccessfully, 
				"Authenticatoin error occured");
		}

		[Test, Category ("LoginFeature")]
		public void OpenHelpDialog ()
		{
			app.Tap (c => c.Button ("Help"));

			Assert.IsTrue (HelpDialogAppeared, 
				"Timed out waiting for password error dialog");

			Assert.IsFalse (IsAuthenticatedSuccessfully, 
				"Authenticatoin error occured");
		}

		[Test, Category ("SearchFeature")]
		public void SearchByName ()
		{
			OpenSearchPage ();
			string searchRequest = "Miguel";
			string expectedResult = "de Icaza";
			Search (searchRequest);

			Assert.IsTrue (CheckSearchResult (expectedResult), 
				"Search by name doesn't work");
		}

		[Test, Category ("PersonalInfo")]
		public void CheckPerosnalInfo ()
		{
			var personalInfo = new PerosnalInfo () { 
				Name = "Joseph",
				Title = "COO",
				Company = "Xamarin",
				Dept = "Developers",
				Twitter = "@josephhill",
				Phone = "1-855-926-2746",
				Email = "joseph@xamarin.com"
			};

			Authenticate ("username", "password");

			SelectEmployee (personalInfo.Name);
			Assert.IsTrue (CheckInformation (personalInfo), 
				"Personal info not properly displayed");
		}

		[Test, Category ("PersonalInfo")]
		public void RemoveFromFavorites ()
		{
			var employeeUnderTest = "Joseph";
			Authenticate ("username", "password");

			SelectEmployee (employeeUnderTest);
			Assert.IsTrue (RemoveFavorite (employeeUnderTest), 
				"Remove from favorites failed");
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
			Authenticate ("username", "password");

			if (app.GetType () == typeof(iOSApp)) {
				app.Tap (c => c.Button ());
			} else {
				app.Tap (c => c.Class("com.android.internal.view.menu.ActionMenuView"));
			}
		}

		private void Authenticate (string username, string password)
		{
			app.EnterText (c => c.Class(TextEntryClassName).Index (0), username);
			app.EnterText (c => c.Class(TextEntryClassName).Index (1), password);
			app.Tap (c => c.Button ("Login"));
		}

		private void SelectEmployee (object name)
		{
			app.Tap (c => c.Raw ("* {text CONTAINS '" + name + "'}"));
		}

		private bool CheckInformation (PerosnalInfo personalInfo)
		{
			foreach (var prop in personalInfo.GetType().GetProperties()) {
				var value = (string)prop.GetValue (personalInfo, null);
				if (!app.Query (c => c.Raw (BuildContainsQuery (value))).Any ())
					return false;
			}

			return true;
		}

		private string BuildContainsQuery (string text)
		{
			return "* {text CONTAINS '" + text + "'}";
		}

		private bool RemoveFavorite (string name)
		{
			app.Tap (c => c.Class(SwitchClassName));
			return app.Query (c => c.Raw (BuildContainsQuery (name))).Any ();
		}
	}

	public class PerosnalInfo
	{
		public string Name { get; set; }

		public string Title { get; set; }

		public string Company { get; set; }

		public string Dept { get; set; }

		public string Twitter { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }
	}
}

