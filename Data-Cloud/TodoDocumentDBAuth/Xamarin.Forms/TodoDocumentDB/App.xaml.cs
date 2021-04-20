using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoDocumentDB
{
	public partial class App : Application
	{
		public static TodoItemManager TodoManager { get; private set; }

		public App()
		{
			InitializeComponent();

			TodoManager = new TodoItemManager(new DocumentDBService());
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
	}
}
