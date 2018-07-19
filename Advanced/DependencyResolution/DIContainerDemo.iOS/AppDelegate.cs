using Foundation;
using UIKit;

namespace DIContainerDemo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            RegisterTypes();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        void RegisterTypes()
        {
            App.RegisterType<ILogger, Logger>();
            App.RegisterType<FormsVideoLibrary.iOS.VideoPlayerRenderer>();
            App.RegisterType<TouchTracking.iOS.TouchEffect>();
            App.RegisterType<IPhotoPicker, Services.iOS.PhotoPicker>();
            App.BuildContainer();
        }
    }
}
