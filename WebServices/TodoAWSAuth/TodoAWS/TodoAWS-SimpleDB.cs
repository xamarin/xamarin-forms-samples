using System;
using System.Linq;
using Xamarin.Forms;

namespace TodoAWSSimpleDB
{
	public class App : Application
	{
		public static string AppName { get { return "TodoListApp"; } }

		public static TodoItemManager TodoManager { get; private set; }

		public static User User { get; set; }

		public static ITextToSpeech Speech { get; set; }

		static NavigationPage NavPage;

		public static bool IsLoggedIn { 
			get { 
				if (User != null)
					return !string.IsNullOrWhiteSpace (User.Email);
				else
					return false;
			} 
		}

		public static Action SuccessfulLoginAction {
			get {
				return new Action (() => { 
					NavPage.Navigation.PopModalAsync ();					

					if (IsLoggedIn) {
						NavPage.Navigation.InsertPageBefore (new TodoListPage (), NavPage.Navigation.NavigationStack.First ());
						NavPage.Navigation.PopToRootAsync ();
					}
				});
			}
		}

		public App ()
		{
			TodoManager = new TodoItemManager (new SimpleDBStorage ());
			User = new User ();

			NavPage = new NavigationPage (new LoginPage ());
			MainPage = NavPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
