using System;
using Xamarin.Forms;

namespace Todo
{
	public static class App
	{
		static TodoItemDatabase database;

		public static Page GetMainPage ()
		{
			var mainNav = new NavigationPage (new TodoListPage ());

			return mainNav;
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

