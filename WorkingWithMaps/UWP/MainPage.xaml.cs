namespace WorkingWithMaps.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("INSERT_MAP_KEY_HERE");
            this.LoadApplication(new WorkingWithMaps.App());
        }
    }
}
