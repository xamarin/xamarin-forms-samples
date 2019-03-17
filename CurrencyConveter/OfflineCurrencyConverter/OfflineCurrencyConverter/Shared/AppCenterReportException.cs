using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfflineCurrencyConverter.Shared
{
    public static class AppCenterReportException
    {
        public static void ReportError(Exception exception, string method, string className)
        {
            if(AppCenter.Configured)
            {
                Crashes.TrackError(exception, new Dictionary<string, string>
                {
                    { "Class", className},
                    { "Method", method }
                });
            }
        }
    }
}
