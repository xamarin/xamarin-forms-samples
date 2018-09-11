using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Firebase;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace DeepLinking.Droid
{
    [Activity(Label = "DeepLinking.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] {
            Intent.ActionView,
            Intent.CategoryDefault,
            Intent.CategoryBrowsable
        },
        DataScheme = "http",
        DataHost = "deeplinking",
        DataPathPrefix = "/",
        AutoVerify = true
        )
    ]

    //[IntentFilter(new[] { Intent.ActionView },
    //    Categories = new[] {
    //        Intent.ActionView,
    //        Intent.CategoryDefault,
    //        Intent.CategoryBrowsable
    //    },
    //    DataScheme = "http",
    //    DataHost = "deeplinking",
    //    DataPathPrefix = "/DeepLinking.TodoItemPage",
    //    AutoVerify = true
    //    )
    //]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //values are to be referred from downloaded google-services.json file
            var options = new FirebaseOptions.Builder()
                                  .SetApplicationId("<client.client_info.mobilesdk_app_id>")
                                  .SetApiKey("<api_key.current_key>")
                                  .SetDatabaseUrl("<project_info.firebase_url>")
                                  .SetGcmSenderId("<oauth_client.client_id>")
                                  .SetStorageBucket("<project_info.storage_bucket>")
                                  .Build();
            var apps = FirebaseApp.GetApps(this);
            if(apps.Count == 0)//to avoid exception
            {
                FirebaseApp.InitializeApp(this,options);
            }

            Xamarin.Forms.Forms.Init(this, bundle);
            AndroidAppLinks.Init(this);

            LoadApplication(new App());
        }
    }


}
