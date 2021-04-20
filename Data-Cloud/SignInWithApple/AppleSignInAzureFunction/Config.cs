using System;
using System.Collections.Generic;
using System.Text;

namespace AppleSignInAzureFunction
{
    // These values should all be stored in your app settings (or local.settings.json for local testing)
    public static class Config
    {
        // This is your apple developer team id as found in the member portal
        public static readonly string TeamId = Environment.GetEnvironmentVariable("APPLE_SIGNIN_TEAM_ID");

        // This is the client id, which is called the server id in the developer portal (on the server type app id you created)
        public static readonly string ServerId = Environment.GetEnvironmentVariable("APPLE_SIGNIN_SERVER_ID"); //eg: com.mydomain.keyname

        // This is the id of the key you created in the developer portal
        public static readonly string KeyId = Environment.GetEnvironmentVariable("APPLE_SIGNIN_KEY_ID"); //Key id of the service id for sign in you created

        // This is the entire text file contents of the .p8 file for the private key you generated
        public static readonly string P8FileContents = Environment.GetEnvironmentVariable("APPLE_SIGNIN_P8_KEY");

        // This is where you want to redirect back on the mobile OS to after we get the token
        // Your app should register as a handler of this protocol
        public static readonly string AppCallbackUri = Environment.GetEnvironmentVariable("APPLE_SIGNIN_APP_CALLBACK_URI");

        // Where Apple should redirect to your server that will handle the token exchange
        public static readonly string RedirectUri = Environment.GetEnvironmentVariable("APPLE_SIGNIN_REDIRECT_URI");
    }
}
