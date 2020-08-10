using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinFormsAppleSignIn.Services;

namespace XamarinFormsAppleSignIn.Droid
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView }, 
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataScheme = Services.WebAppleSignInService.CallbackUriScheme)]
    public class AppleSignInCallbackActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var url = Intent.Data.ToString();

            Xamarin.Forms.DependencyService.Get<IAppleSignInService>().Callback(url);

            Finish();
        }
    }
}