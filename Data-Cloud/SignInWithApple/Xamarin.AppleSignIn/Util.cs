using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Xamarin.AppleSignIn
{
    public static class Util
    {
        public static string GenerateNonce()
            => GenerateRandom(32);
        public static string GenerateState()
            => GenerateRandom(12);

        static string GenerateRandom(int len)
        {
            var random = RandomNumberGenerator.Create();
            var data = new byte[len];
            random.GetNonZeroBytes(data);
            return Base64UrlEncode(data);
        }

        internal static string Sha256AtHash(string token)
        {
            var crypt = SHA256.Create();
            var hashBytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(token));
            return Base64UrlEncode(hashBytes, 0, 16);
        }

        internal static string Base64UrlEncode(byte[] data)
            => Base64UrlEncode(data, 0, data.Length);

        internal static string Base64UrlEncode(byte[] data, int offset, int length)
        {
            var base64 = Convert.ToBase64String(data, offset, length);
            var base64Url = new StringBuilder();

            foreach (var c in base64)
            {
                if (c == '+')
                    base64Url.Append('-');
                else if (c == '/')
                    base64Url.Append('_');
                else if (c == '=')
                    break;
                else
                    base64Url.Append(c);
            }

            return base64Url.ToString();
        }

        internal static byte[] Base64UrlDecode(string encoded)
        {
            var decoded = encoded;
            decoded = decoded.Replace('_', '/');
            decoded = decoded.Replace('-', '+');

            // Figure out if we need to pad with trailing = 
            switch (decoded.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    decoded += "==";
                    break;
                case 3:
                    decoded += "=";
                    break;
            }

            return Convert.FromBase64String(decoded);
        }

        public static IDictionary<string, string> ParseUrlParameters(string url)
        {
            var d = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(url))
                return d;

            var queryString = url;
            if (url.Contains("#"))
                queryString = url.Substring(url.IndexOf('#') + 1);
            else if (url.Contains("?"))
                queryString = url.Substring(url.IndexOf('?') + 1);

            var pairs = queryString.Split('&');

            if (pairs == null || !pairs.Any())
                return d;

            foreach (var kvp in pairs)
            {
                var pair = kvp.Split(new char[] { '=' }, 2);

                if (pair == null || pair.Length != 2)
                    continue;

                d[pair[0]] = pair[1];
            }

            return d;
        }
    }
}
