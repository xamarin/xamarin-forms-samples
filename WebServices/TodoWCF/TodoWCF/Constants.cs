using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoWCF
{
    public static class Constants
    {
    public static string SoapUrl
    {
        get
        {
            var defaultUrl = "http://localhost:49393/TodoService.svc";

            if(Device.RuntimePlatform == Device.Android)
            {
                defaultUrl = "http://10.0.2.2:49393/TodoService.svc";
            }

            // NOTE: you may need to add another condition for iOS if you are
            // accessing the SoapUrl on another machine

            return defaultUrl;
        }
    }
    }
}
