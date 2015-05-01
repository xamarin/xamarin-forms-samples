using System;
using Xamarin.Forms;

namespace Todo
{
	public class App : Application
	{

		static TodoItemDatabase database;

		public App ()
		{
			database = new TodoItemDatabase ();
			var mainNav = new NavigationPage (new TodoListPage ());
			MainPage = mainNav;
		}

		public static TodoItemDatabase Database {
			get {
				return database;
			}
		}
	}
}

