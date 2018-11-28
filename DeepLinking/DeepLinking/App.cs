using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeepLinking
{
    public class App : Application
    {
        public static string AppName = "DeepLinking";

        static TodoItemDatabase database;
        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

        public App()
        {
            MainPage = new NavigationPage(new TodoListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override async void OnAppLinkRequestReceived(Uri uri)
        {
            string appDomain = "http://" + App.AppName.ToLowerInvariant() + "/";
            if (!uri.ToString().ToLowerInvariant().StartsWith(appDomain, StringComparison.Ordinal))
                return;

            string pageUrl = uri.ToString().Replace(appDomain, string.Empty).Trim();
            var parts = pageUrl.Split('?');
            string page = parts[0];
            string pageParameter = parts[1].Replace("id=", string.Empty);

            var formsPage = Activator.CreateInstance(Type.GetType(page));
            var todoItemPage = formsPage as TodoItemPage;
            if (todoItemPage != null)
            {
                var todoItem = await App.Database.GetItemAsync(int.Parse(pageParameter));
                todoItemPage.BindingContext = todoItem;
                await MainPage.Navigation.PushAsync(formsPage as Page);
            }

            base.OnAppLinkRequestReceived(uri);
        }
    }
}
