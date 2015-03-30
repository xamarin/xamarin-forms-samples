using System;
using Xamarin.Forms;

namespace Todo
{
	public class App : Application
	{
		public static Page GetMainPage ()
		{
			database = new TodoItemDatabase();

			var mainNav = new NavigationPage (new TodoListPage ());

			return mainNav;
		}

		static TodoItemDatabase database;
		public static TodoItemDatabase Database {
			get { return database; }
		}
	}
}

