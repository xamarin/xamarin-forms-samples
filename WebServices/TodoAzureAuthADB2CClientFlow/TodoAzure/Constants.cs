namespace TodoAzure
{
    public static class Constants
    {
        // Replace strings with your own values
        // Azure Active Directory B2C
        public static readonly string Tenant = "INSERT_TENANT_HERE"; // Domain/resource name from AD B2C
        public static readonly string ClientID = "INSERT_CLIENTID_HERE"; // Application ID from AD B2C
        public static readonly string PolicySignUpSignIn = "INSERT_POLICY_HERE"; // Policy name from AD B2C
        public static readonly string[] Scopes = { "" }; // Leave blank unless additional scopes have been added to AD B2C
        public static string AuthorityBase = $"https://login.microsoftonline.com/tfp/{Tenant}/"; // Doesn't require editing
        public static string Authority = $"{AuthorityBase}{PolicySignUpSignIn}"; // Doesn't require editing
        public static readonly string URLScheme = "INSERT_URL_SCHEME_HERE"; // Custom Redirect URI from AD B2C (without ://auth/)
        public static readonly string RedirectUri = $"{URLScheme}://auth"; // Doesn't require editing

        // Azure Mobile App
        public static readonly string AzureMobileAppURL = @"INSERT_MOBILE_APP_URL_HERE";
    }
}
