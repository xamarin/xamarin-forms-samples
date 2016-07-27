namespace TodoAWS.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            TodoAWSSimpleDB.App.Speech = new Speech();
            this.LoadApplication(new TodoAWSSimpleDB.App());
        }
    }
}
