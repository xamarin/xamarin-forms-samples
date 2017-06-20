using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace TodoAWSSimpleDB.Droid
{
    [Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop )]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new [] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataSchemes = new [] { "com.googleusercontent.apps.863494635082-490jbiltg6bqbar4eccr197al8ggjskk" },
        DataPath = "/oauth2redirect")]
    public class CustomUrlSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Convert Android.Net.Url to Uri
            var uri = new Uri(Intent.Data.ToString());

            // Load redirectUrl page
            AuthenticationState.Authenticator.OnPageLoading(uri);

            Finish();
		}
    }
}
