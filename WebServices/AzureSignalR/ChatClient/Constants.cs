using Xamarin.Forms;

namespace ChatClient
{
    public static class Constants
    {
        // NOTE: If testing locally, use http://localhost:7071
        // otherwise enter your Azure Function App url
        // For example: http://YOUR_FUNCTION_APP_NAME.azurewebsites.net
        public static string HostName { get; set; } = "< INSERT AZURE FUNCTIONS APP URL HERE >";

        public static string MessageName { get; set; } = "newMessage";

        public static string Username
        {
            get
            {
                return $"{Device.RuntimePlatform} User";
            }
        }
    }
}
