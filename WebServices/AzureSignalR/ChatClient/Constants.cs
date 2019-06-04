using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatClient
{
    public static class Constants
    {
        public static string HostName { get; set; } = "http://localhost:7071";

        public static string Username
        {
            get
            {
                return $"{Device.RuntimePlatform} User";
            }
        }
    }
}
