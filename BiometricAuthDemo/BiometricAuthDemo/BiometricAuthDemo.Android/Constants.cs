using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Security.Keystore;
using Android.Views;
using Android.Widget;

namespace BiometricAuthDemo.Droid
{
    public static class Constants
    {
        // Auth callback settings
        public static readonly byte[] SecretBytes = {1, 2, 3, 4, 5, 6, 7, 8, 9};

        // Crypto helper settings
        public static readonly string KeyName = "com.xamarin.forms.biometricauth";
        public static readonly string StoreName = "AndroidKeyStore";
        public static readonly string KeyAlgo = KeyProperties.KeyAlgorithmAes;
        public static readonly string BlockMode = KeyProperties.BlockModeCbc;
        public static readonly string EncryptionPadding = KeyProperties.EncryptionPaddingPkcs7;
        public static readonly string Transformation = $@"{KeyAlgo}/{BlockMode}/{EncryptionPadding}";
    }
}