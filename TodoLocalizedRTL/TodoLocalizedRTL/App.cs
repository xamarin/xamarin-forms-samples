using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TodoLocalized.Resx;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoLocalized
{
    public class App : Application
    {
        static TodoItemDatabase database;

        public App()
        {
            AppResources.Culture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            MainPage = new NavigationPage(new TodoListPageXaml());
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

