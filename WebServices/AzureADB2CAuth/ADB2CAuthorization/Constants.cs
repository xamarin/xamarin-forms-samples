namespace ADB2CAuthorization
{
    public static class Constants
    {
        // set your tenant name, for example "contoso123tenant"
        static readonly string tenantName = "<INSERT_YOUR_TENANT_NAME>";

        // set your tenant id, for example: "contoso123tenant.onmicrosoft.com"
        static readonly string tenantId = "<INSERT_YOUR_TENANT_ID>";

        // set your client/application id, for example: aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
        static readonly string clientId = "<INSERT_YOUR_CLIENT_ID>";

        // set your sign up/in policy name, for example: "B2C_1_signupsignin"
        static readonly string policySignin = "<INSERT_SIGNUP_SIGNIN_POLICY_NAME>";

        // set your forgot password policy, for example: "B2C_1_passwordreset"
        static readonly string policyPassword = "<INSERT_PASSWORD_RESET_POLICY_NAME>";



        // The following fields and properties should not need to be changed
        static readonly string[] scopes = { "" };
        static readonly string authorityBase = $"https://{tenantName}.b2clogin.com/tfp/{tenantId}/";
        public static string ClientId
        {
            get
            {
                return clientId;
            }
        }
        public static string AuthoritySignin
        {
            get
            {
                return $"{authorityBase}{policySignin}";
            }
        }
        public static string AuthorityPasswordReset
        {
            get
            {
                return $"{authorityBase}{policyPassword}";
            }
        }
        public static string[] Scopes
        {
            get
            {
                return scopes;
            }
        }
    }
}
