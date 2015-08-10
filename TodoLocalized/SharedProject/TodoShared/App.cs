using System;
using Xamarin.Forms;
using System.Reflection;

namespace TodoLocalized
{
	public class App : Xamarin.Forms.Application
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

			var assembly = typeof(App).GetTypeInfo().Assembly;
			foreach (var res in assembly.GetManifestResourceNames())
				System.Diagnostics.Debug.WriteLine(" ### found resource: " + res);
		}
	}
}