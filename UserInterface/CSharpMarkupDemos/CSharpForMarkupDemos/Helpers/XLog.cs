using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
#if WINDOWS_UWP
using Windows.Foundation.Diagnostics;
#endif

namespace CSharpForMarkupDemos.Helpers
{
    /// <summary>
    /// Cross-platform logging helper class for use in Xamarin apps.
    /// </summary>
    public static class XLog
    {
        static string rootFolderPattern = null;
#if WINDOWS_UWP
        static LoggingChannel loggingChannel;
#endif

        /// <summary>
        /// Call this before logging starts.
        /// </summary>
        /// <param name="rootFolderPattern">Should match the top folder name(s) within the source control repository, e.g. @"\MobileRealtimePush\MobileRealtimePush\". Any folders before the first match of this pattern are omitted from the logged source file paths</param>
        public static void Init(string rootFolderPattern = null)
        {
            XLog.rootFolderPattern = rootFolderPattern;
#if WINDOWS_UWP
            loggingChannel = new LoggingChannel("XLog provider", null, new Guid("4bd2826e-54a1-4ba9-bf63-92b73ea1ac4a"));
#endif
        }


        /// <summary>
        /// If the DEBUG constant is defined in a build, DebugLog logs to the debug output and to the native logging 
        /// mechanism of the mobile platform (NSLog on iOS or android.util.Log on Android).
        /// 
        /// String format: "[tag] memberName: data sourcefilePath:sourceLineNumber"
        /// </summary>
        /// <remarks>
        /// In a release build both this method and any calls to it are compiled away.
        /// </remarks>
        /// <param name="data">object to log as ToString()</param>
        /// <param name="tag">optional prefix</param>
        /// <param name="memberName">supplied by compiler, no need to specify in code unless you want to pass a deeper call context</param>
        /// <param name="sourceFilePath">supplied by compiler, no need to specify in code unless you want to pass a deeper call context</param>
        /// <param name="sourceLineNumber">supplied by compiler, no need to specify in code unless you want to pass a deeper call context</param>
        [Conditional("DEBUG")]
        public static void Debug(
            object data = null,
            string tag = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = -1)
        {
            string message = FormatLogString(data, tag, memberName, sourceFilePath, sourceLineNumber);
            System.Diagnostics.Debug.WriteLine(message);
#if WINDOWS_UWP
            loggingChannel?.LogMessage(message, LoggingLevel.Verbose); // For ETW logging through UWP Device Portal. Read more at https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/#1CvyvpPD4lUTtPzc.99   
#endif
        }

        /// <summary>
        /// If the TRACE constant is defined in a build, TraceLog logs to the trace output and to the native logging 
        /// mechanism of the mobile platform (NSLog on iOS or android.util.Log on Android).
        /// 
        /// String format: "[tag] memberName: data sourcefilePath:sourceLineNumber"
        /// </summary>
        /// <remarks>
        /// If the TRACE constant is not defined in a build, both this method and any calls to it are compiled away.
        /// </remarks>
        /// <param name="data">object to log as ToString()</param>
        /// <param name="tag">optional prefix</param>
        /// <param name="memberName">supplied by compiler, no need to specify in code unless you want to pass a deeper call context</param>
        /// <param name="sourceFilePath">supplied by compiler, no need to specify in code unless you want to pass a deeper call context</param>
        /// <param name="sourceLineNumber">supplied by compiler, no need to specify in code unless you want to pass a deeper call context</param>
        [Conditional("TRACE")]
        public static void Trace(
            object data = null,
            string tag = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = -1)
        {
            string message = FormatLogString(data, tag, memberName, sourceFilePath, sourceLineNumber);
#if WINDOWS_UWP
            System.Diagnostics.Debug.WriteLine(message);
            loggingChannel?.LogMessage(message, LoggingLevel.Information); // For ETW logging through UWP Device Portal. Read more at https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/#1CvyvpPD4lUTtPzc.99   
#else
            System.Diagnostics.Trace.WriteLine(message);
#endif
        }

        public static string TruncateAt(this string s, int maxLength, string truncatedSuffix = "...") => s?.Length <= maxLength ? s : s.Substring(0, maxLength) + truncatedSuffix;

        static string FormatLogString(object data = null, string tag = null, string memberName = null, string sourceFilePath = null, int sourceLineNumber = -1)
        {

            StringBuilder line = new StringBuilder();

            if (!string.IsNullOrEmpty(tag))
            {
                if (line.Length > 0) line.Append(' ');
                line.Append('[');
                line.Append(tag);
                line.Append(']');
            }

            if (!string.IsNullOrEmpty(memberName))
            {
                if (line.Length > 0) line.Append(' ');
                line.Append(memberName);
                line.Append(':');
            }

            string dataString = data?.ToString();
            if (!string.IsNullOrEmpty(dataString))
            {
                if (line.Length > 0) line.Append(' ');
                line.Append(dataString);
            }

            if (!string.IsNullOrEmpty(sourceFilePath))
            {
                if (!string.IsNullOrEmpty(rootFolderPattern))
                {
                    int rootFolderIndex = sourceFilePath.IndexOf(rootFolderPattern);
                    if (rootFolderIndex >= 0) sourceFilePath = sourceFilePath.Substring(rootFolderIndex);
                }

                if (line.Length > 0) line.Append(' ');
                line.Append("at ");
                line.Append(sourceFilePath);

                if (sourceLineNumber >= 0)
                {
                    line.Append(":");
                    line.Append(sourceLineNumber);
                }
            }

            return line.ToString();
        }
    }
}
