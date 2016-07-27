namespace TodoParse.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            TodoParse.App.TodoManager = new TodoItemManager(ParseStorage.Default);
            TodoParse.App.Speech = new Speech();
            this.LoadApplication(new TodoParse.App());
        }
    }
}
