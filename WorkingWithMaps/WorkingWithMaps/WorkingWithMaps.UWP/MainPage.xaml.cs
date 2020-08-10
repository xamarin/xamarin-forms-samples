namespace WorkingWithMaps.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("INSERT_AUTH_TOKEN_HERE");
            Windows.Services.Maps.MapService.ServiceToken = "INSERT_AUTH_TOKEN_HERE";
            LoadApplication(new WorkingWithMaps.App());
        }
    }
}
