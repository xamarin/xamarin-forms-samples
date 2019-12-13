using Android.Security.Keystore;
using Android.Support.V4.Hardware.Fingerprint;
using Java.Security;
using Javax.Crypto;
using System;

namespace BiometricAuthDemo.Droid
{
    public class CryptoObjectHelper
    {
        readonly KeyStore keystore;

        public CryptoObjectHelper()
        {
            keystore = KeyStore.GetInstance(Constants.StoreName);
            keystore.Load(null);
        }

        public FingerprintManagerCompat.CryptoObject BuildCryptoObject()
        {
            Cipher cipher = CreateCipher();
            return new FingerprintManagerCompat.CryptoObject(cipher);
        }

        Cipher CreateCipher(bool retry = true)
        {
            IKey key = GetKey();

            Cipher cipher = Cipher.GetInstance(Constants.Transformation);
            try
            {
                cipher.Init(CipherMode.EncryptMode, key);
            }
            catch (KeyPermanentlyInvalidatedException e)
            {
                keystore.DeleteEntry(Constants.KeyName);
                if (retry)
                {
                    CreateCipher(false);
                }
                else
                {
                    throw new Exception("Could not create the cipher for fingerprint authentication.", e);
                }
            }
            return cipher;
        }

        IKey GetKey()
        {
            if (!keystore.IsKeyEntry(Constants.KeyName))
            {
                CreateKey();
            }

            IKey secretKey = keystore.GetKey(Constants.KeyName, null);
            return secretKey;
        }

        void CreateKey()
        {
            KeyGenerator keyGen = KeyGenerator.GetInstance(Constants.KeyAlgo, Constants.StoreName);
            KeyGenParameterSpec keyGenSpec =
                new KeyGenParameterSpec.Builder(Constants.KeyName, KeyStorePurpose.Encrypt | KeyStorePurpose.Decrypt)
                    .SetBlockModes(Constants.BlockMode)
                    .SetEncryptionPaddings(Constants.EncryptionPadding)
                    .SetUserAuthenticationRequired(true)
                    .Build();
            keyGen.Init(keyGenSpec);
            keyGen.GenerateKey();
        }
    }
}