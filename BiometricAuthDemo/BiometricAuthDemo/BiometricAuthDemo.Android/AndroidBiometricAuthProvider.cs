using Android;
using Android.App;
using Android.Support.V4.Content;
using Android.Support.V4.Hardware.Fingerprint;
using System;
using Dependency = Xamarin.Forms.DependencyAttribute;

[assembly: Dependency(typeof(BiometricAuthDemo.Droid.AndroidBiometricAuthProvider))]
namespace BiometricAuthDemo.Droid
{
    public class AndroidBiometricAuthProvider : IBiometricAuthProvider
    {
        FingerprintManagerCompat fingerprintManager;
        bool hasPermissions;

        public bool IsBiometricAuthEnabled
        {
            get
            {
                return hasPermissions &&
                    fingerprintManager.IsHardwareDetected &&
                    fingerprintManager.HasEnrolledFingerprints;
            }
        }

        public void RequestAuthentication(Action<BiometricAuthResult> completionCallback)
        {
            CryptoObjectHelper cryptoHelper = new CryptoObjectHelper();
            var cancellationSignal = new Android.Support.V4.OS.CancellationSignal();
            var authCallback = new BiometricAuthenticationCallback(completionCallback);
            fingerprintManager.Authenticate(cryptoHelper.BuildCryptoObject(),
                Constants.AuthenticationFlags,
                cancellationSignal,
                authCallback,
                null);
        }

        public AndroidBiometricAuthProvider()
        {
            var context = Application.Context;

            Android.Content.PM.Permission result = ContextCompat.CheckSelfPermission(context, Manifest.Permission.UseBiometric);
            if (result == Android.Content.PM.Permission.Granted)
            {
                hasPermissions = true;
                fingerprintManager = FingerprintManagerCompat.From(context);
            }
            else
            {
                // NOTE: request permissions here
                hasPermissions = false;
            }
        }
    }
}