namespace TodoASMX.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            TodoASMX.App.Speech = new Speech();
            TodoASMX.App.TodoManager = new TodoItemManager(new SoapService());

            this.LoadApplication(new TodoASMX.App());
        }
    }
}
