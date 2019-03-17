using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfflineCurrencyConverter.Shared
{
    public class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        private const string First_Time_Run = "firstTime";
        private static readonly string FirstTimeDefault = true.ToString();

        /// <summary>
        /// Tells if the user is running this app for the first time.
        /// </summary>
        public static bool IsFirstTimeRun
        {
            get => Convert.ToBoolean(AppSettings.GetValueOrDefault(First_Time_Run, FirstTimeDefault));
            set => AppSettings.AddOrUpdateValue(First_Time_Run, Convert.ToString(value));
        }
    }
}
