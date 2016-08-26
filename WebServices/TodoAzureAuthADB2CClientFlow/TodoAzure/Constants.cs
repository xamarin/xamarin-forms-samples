namespace TodoAzure
{
	public static class Constants
	{
		// Replace strings with your mobile services and gateway URLs.
		public static readonly string ApplicationURL = @"<INSERT_MOBILE_APP_URL_HERE>";

		public static readonly string ApplicationID = "<INSERT_ADB2C_APP_ID_HERE>";
		public static readonly string[] Scopes = { ApplicationID };
		public static readonly string SignUpSignInPolicy = "<INSERT_AD_B2C_POLICY_NAME_HERE>";
		public static readonly string Authority = "<INSERT_AUTHORITY_HERE>";
	}
}
