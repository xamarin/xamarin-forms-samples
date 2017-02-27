using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoAWSSimpleDB
{
	public class App : Application
	{
		public static TodoItemManager TodoManager { get; private set; }
		public static User User { get; set; }
		public static ITextToSpeech Speech { get; set; }

		public App()
		{
			TodoManager = new TodoItemManager(new SimpleDBStorage());
			User = new User();

			MainPage = new NavigationPage(new LoginPage());
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
	}
}
