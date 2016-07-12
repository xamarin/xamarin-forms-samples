using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeepLinking
{
	public class App : Application
	{
		public static string AppName = "DeepLinking";

		public static TodoItemDatabase Database { get; private set; }

		public App()
		{
			Database = new TodoItemDatabase();
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
			{
				return;
			}

			string pageUrl = uri.ToString().Replace(appDomain, string.Empty).Trim();
			var parts = pageUrl.Split('?');
			string page = parts[0];
			string pageParameter = parts[1].Replace("id=", string.Empty);

			var formsPage = Activator.CreateInstance(Type.GetType(page));
			var todoItemPage = formsPage as TodoItemPage;
			if (todoItemPage != null)
			{
				var todoItem = App.Database.Find(pageParameter);
				todoItemPage.BindingContext = todoItem;
				await MainPage.Navigation.PushAsync(formsPage as Page);
			}

			base.OnAppLinkRequestReceived(uri);
		}
	}
}
