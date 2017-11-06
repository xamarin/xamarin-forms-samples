namespace TodoAzure
{
    public static class Constants
    {
        // Replace strings with your own values
        // Azure Active Directory B2C
        public static readonly string Tenant = "INSERT_TENANT_HERE";
        public static readonly string ClientID = "INSERT_CLIENTID_HERE";
        public static readonly string PolicySignUpSignIn = "INSERT_POLICY_HERE";
        public static readonly string[] Scopes = { "" };
        public static string AuthorityBase = $"https://login.microsoftonline.com/tfp/{Tenant}/";
        public static string Authority = $"{AuthorityBase}{PolicySignUpSignIn}";
        public static readonly string URLScheme = "INSERT_URL_SCHEME_HERE";
        public static readonly string RedirectUri = $"{URLScheme}://auth";

        // Azure Mobile App
        public static readonly string AzureMobileAppURL = @"INSERT_MOBILE_APP_URL_HERE";
    }
}
