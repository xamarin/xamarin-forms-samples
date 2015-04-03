using System;
using Xamarin.Forms;

namespace Todo
{
	public class App : Application
	{
		static TodoItemDatabase database;
		public static TodoItemDatabase Database {
			get {
				database = database ?? new TodoItemDatabase ();
				return database;
			}
		}

		public App()
		{
			MainPage = new NavigationPage (new TodoListPage ());
		}
	}
}