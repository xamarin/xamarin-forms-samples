namespace DIContainerDemo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            RegisterTypes();
            this.LoadApplication(new DIContainerDemo.App());
        }

        void RegisterTypes()
        {
            DIContainerDemo.App.RegisterType<ILogger, Logger>();
            DIContainerDemo.App.RegisterType<FormsVideoLibrary.UWP.VideoPlayerRenderer>();
            DIContainerDemo.App.RegisterType<TouchTracking.UWP.TouchEffect>();
            DIContainerDemo.App.RegisterType<IPhotoPicker, Services.UWP.PhotoPicker>();
            DIContainerDemo.App.BuildContainer();
        }
    }
}
