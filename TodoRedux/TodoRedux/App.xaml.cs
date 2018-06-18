using Redux;
using TodoRedux.ActionCreators;
using TodoRedux.Helpers;
using TodoRedux.Middleware;
using TodoRedux.State;
using TodoRedux.Views;
using Xamarin.Forms;

namespace TodoRedux
{
    public partial class App : Application
    {
        public static IStore<ApplicationState> Store { get; private set; }

        public App()
        {
            InitializeComponent();

            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("todo.db");
            Store = new Store<ApplicationState>(
                Reducers.Reducers.ReduceApplication, 
                new ApplicationState(),
                new DatabaseMiddleware<ApplicationState>(dbPath).CreateMiddleware());

            var nav = new NavigationPage(new TodoListPage());
			nav.BarBackgroundColor = (Color)App.Current.Resources["titleBarBackground"];
			nav.BarTextColor = Color.White;

			MainPage = nav;
        }

        protected override void OnStart()
        {
            Store.Dispatch(TodoActionCreators.FetchAll());
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
