using Android.Support.V4.Hardware.Fingerprint;
using Java.Lang;
using System;

namespace BiometricAuthDemo.Droid
{
    public class BiometricAuthenticationCallback : FingerprintManagerCompat.AuthenticationCallback
    {
        Action<BiometricAuthResult> authCallback;

        public BiometricAuthenticationCallback(Action<BiometricAuthResult> callback)
        {
            this.authCallback = callback;
        }

        public override void OnAuthenticationSucceeded(FingerprintManagerCompat.AuthenticationResult result)
        {
            if(result.CryptoObject.Cipher != null)
            {
                try
                {
                    byte[] doFinalResult = result.CryptoObject.Cipher.DoFinal(Constants.SecretBytes);

                    // If no errors occurred the attempt succeeded
                    TryPerformCallback(true, "Authentication successful!");
                }
                catch(System.Exception ex)
                {
                    TryPerformCallback(false, "Unexpected result from authentication process.");
                }
            }

            // No cipher was used so success is assumed
            else
            {
                TryPerformCallback(true, "Authentication successful!");
            }
        }

        public override void OnAuthenticationError(int errMsgId, ICharSequence errString)
        {
            TryPerformCallback(false, errString.ToString());
        }

        public override void OnAuthenticationFailed()
        {
            TryPerformCallback(false, "Authentication failed: fingerprint was not recognized");
        }

        public override void OnAuthenticationHelp(int helpMsgId, ICharSequence helpString)
        {
            TryPerformCallback(false, $"Failed to authenticate user: {helpString}");
        }

        void TryPerformCallback(bool success, string message = null)
        {
            if(authCallback != null)
            {
                var result = new BiometricAuthResult
                {
                    Success = success,
                    Message = message
                };

                authCallback(result);
            }
        }
    }
}