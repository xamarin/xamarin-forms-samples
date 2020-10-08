namespace DataBindingDemos.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new DataBindingDemos.App());
        }
    }
}
