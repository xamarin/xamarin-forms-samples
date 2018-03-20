using System;
using Xamarin.Forms;
using TodoLocalized.Resx;

namespace TodoLocalized
{
    public class App : Application
    {
        static TodoItemDatabase database;

        public App()
        {
            var ci = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            L10n.SetLocale(ci);
            AppResources.Culture = ci;

            var mainNav = new NavigationPage(new TodoListPage());
            MainPage = mainNav;
        }

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase();
                }
                return database;
            }
        }
    }
}

