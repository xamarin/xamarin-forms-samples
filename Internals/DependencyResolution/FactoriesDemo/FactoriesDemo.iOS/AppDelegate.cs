using Foundation;
using UIKit;

namespace FactoriesDemo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            RegisterFactories();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        void RegisterFactories()
        {
            App.Register(typeof(FormsVideoLibrary.iOS.VideoPlayerRenderer), (o) => new FormsVideoLibrary.iOS.VideoPlayerRenderer(new Logger()));
            App.Register(typeof(TouchTracking.iOS.TouchEffect), (o) => new TouchTracking.iOS.TouchEffect(new Logger()));
            App.Register(typeof(IPhotoPicker), (o) => new Services.iOS.PhotoPicker(new Logger()));
        }
    }
}
