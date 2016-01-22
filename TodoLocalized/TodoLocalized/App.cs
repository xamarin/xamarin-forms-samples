using System;
using Xamarin.Forms;
using TodoLocalized.Resx;
using System.Globalization;

namespace TodoLocalized
{
	public class App : Application
	{
		static TodoItemDatabase database;

		public App ()
		{
			L10n.SetLocale ();

			var netLanguage = DependencyService.Get<ILocale>().GetCurrent();
			AppResources.Culture = new CultureInfo (netLanguage);

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

