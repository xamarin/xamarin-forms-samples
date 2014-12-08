using System;
using Xamarin.Forms;

namespace Todo
{
	public class App : Application
	{
		static TodoItemDatabase database;

		public App ()
		{
			var mainNav = new NavigationPage (new TodoListPage ());

			MainPage = mainNav;
		}

		public static TodoItemDatabase Database {
			get { 
				if (database == null) {
					database = new TodoItemDatabase ();
				}
				return database; 
			}
		}
	}
}

