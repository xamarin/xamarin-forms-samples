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

		public App ()
		{
			Resources = new ResourceDictionary ();
			Resources.Add ("primaryGreen", Color.FromHex("91CA47"));
			Resources.Add ("primaryDarkGreen", Color.FromHex ("6FA22E"));

			var nav = new NavigationPage (new TodoListPage ());
			nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
			nav.BarTextColor = Color.White;

			MainPage = nav;
		}
	}
}