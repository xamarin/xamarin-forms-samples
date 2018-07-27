namespace FactoriesDemo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            RegisterFactories();
            this.LoadApplication(new FactoriesDemo.App());
        }

        void RegisterFactories()
        {
            FactoriesDemo.App.Register(typeof(FormsVideoLibrary.UWP.VideoPlayerRenderer), (o) => new FormsVideoLibrary.UWP.VideoPlayerRenderer(new Logger()));
            FactoriesDemo.App.Register(typeof(TouchTracking.UWP.TouchEffect), (o) => new TouchTracking.UWP.TouchEffect(new Logger()));
            FactoriesDemo.App.Register(typeof(IPhotoPicker), (o) => new Services.UWP.PhotoPicker(new Logger()));
        }
    }
}
