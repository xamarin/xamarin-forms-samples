using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatClient
{
    public static class Constants
    {
        public static string HostName { get; set; } = "https://xdocsfunctions.azurewebsites.net/";

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
