using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using CognitiveSpeechService.Services;
using Xamarin.Forms;
using CognitiveSpeechService.Droid.Services;

namespace CognitiveSpeechService.Droid
{
    [Activity(Label = "CognitiveSpeechService", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        IMicrophoneService micService;
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            micService = DependencyService.Resolve<IMicrophoneService>();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            switch (requestCode)
            {
                case AndroidMicrophoneService.RecordAudioPermissionCode:
                    if(grantResults[0] == Permission.Granted)
                    {
                        micService.OnRequestPermissionResult(true);
                    }
                    else
                    {
                        micService.OnRequestPermissionResult(false);
                    }
                    break;
            }
        }
    }
}