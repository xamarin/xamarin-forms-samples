using Android;
using Android.App;
using Android.Hardware.Fingerprints;
using Android.Support.V4.Content;
using Android.Support.V4.Hardware.Fingerprint;
using System;
using System.Threading;
using Dependency = Xamarin.Forms.DependencyAttribute;

[assembly: Dependency(typeof(BiometricAuthDemo.Droid.AndroidBiometricAuthProvider))]
namespace BiometricAuthDemo.Droid
{
    public class AndroidBiometricAuthProvider : IBiometricAuthProvider
    {
        FingerprintManagerCompat fingerprintManager;
        bool hasPermissions;
        CryptoObjectHelper cryptoHelper;

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
            var cancellationSignal = new Android.Support.V4.OS.CancellationSignal();
            var authCallback = new BiometricAuthenticationCallback(completionCallback);

            fingerprintManager.Authenticate(cryptoHelper.BuildCryptoObject(),
                (int)FingerprintAuthenticationFlags.None,
                cancellationSignal,
                authCallback,
                null);
        }

        public void Init()
        {
            var context = Application.Context; //(Activity)context;
            cryptoHelper = new CryptoObjectHelper();

            Android.Content.PM.Permission result = ContextCompat.CheckSelfPermission(context, Manifest.Permission.UseBiometric);
            if (result == Android.Content.PM.Permission.Granted)
            {
                hasPermissions = true;
                fingerprintManager = FingerprintManagerCompat.From(context);
            }
            else
            {
                // NOTE: try to request permissions here
                hasPermissions = false;
            }
        }

        public AndroidBiometricAuthProvider()
        {
            
        }

        
    }
}