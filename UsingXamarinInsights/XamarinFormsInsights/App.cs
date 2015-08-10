using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Cryptography;

namespace HoustonForms
{
	public class App : Application
    {
        public App()
        {	
			// Insights gets initialized in each platform-specific project
			// iOS: Main.cs
			// Android: MainActivity.cs

            MainPage = new MakeContent().GenerateContent();
        }
    }

    public class MakeContent
    {
        // accessor to the event routine used for the timers
        public WorkCompletedEvent WorkCompleted { get; set; }

        IFolder rootFolder = FileSystem.Current.LocalStorage;

        public ContentPage GenerateContent()
        {
            var btnCrashApp = new Button
            {
                Text = "Additional information reports"
            };
            var btnDivByZero = new Button
            {
                Text = "Divide by zero"
            };
            var btnFileException = new Button
            {
                Text = "File exception"
            };
            var btnNullRef = new Button
            {
                Text = "Null ref"
            };
            var btnPartialInfo = new Button
            {
                Text = "Partial info"
            };
            var btnStartMultiTracker = new Button
            {
                Text = "Start mult tracker"
            };
            var btnStartTimer = new Button
            { 
                Text = "Start timer"
            };
            var btnSingle = new Button
            {
                Text = "Single identity"
            };
            var btnMultipleId = new Button
            {
                Text = "Multiple Identities"
            };
            var stackIds = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White,
                Children =
                {
                    new Label { Text = "Identities" },
                    new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.FillAndExpand, Children = { btnSingle, btnMultipleId } },
                    new Label { Text = "Divide By Zero" },
                    new StackLayout{ HorizontalOptions = LayoutOptions.Center, Children = { btnDivByZero } },
                    new Label { Text = "Additional information reports" },
                    new StackLayout{ Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.FillAndExpand, Children = { btnFileException, btnNullRef, btnPartialInfo } },
                    new Label { Text = "Uncaught exception" },
                    new StackLayout{ HorizontalOptions = LayoutOptions.Center, Children = { btnCrashApp } },
                    new Label { Text = "Timer tracking" },
                    new StackLayout{ HorizontalOptions = LayoutOptions.Center, Children = { btnStartTimer } },
                    new Label { Text = "Multiple tracking" },
                    new StackLayout{ HorizontalOptions = LayoutOptions.Center, Children = { btnStartMultiTracker } }
                }
            };

            var content = new ContentPage
            {
                Content = stackIds,
				Padding = new Thickness(0,20,0,0) // really just for iOS
            };
                        
            btnCrashApp.IsEnabled = btnDivByZero.IsEnabled = btnFileException.IsEnabled = btnNullRef.IsEnabled = btnPartialInfo.IsEnabled = btnStartMultiTracker.IsEnabled = btnStartTimer.IsEnabled = false;

            // let's identify the user of this software. This can be a single person, or a group of people (perhaps from a group subscription to an app)

            // 1. For a single user
            // The format is unique identifier, key, value

            btnSingle.Clicked += delegate
            {
                Insights.Identify("alan_user@xamarin.com", "Name", "Alan James User");
                btnCrashApp.IsEnabled = btnDivByZero.IsEnabled = btnFileException.IsEnabled = btnNullRef.IsEnabled = btnPartialInfo.IsEnabled = btnStartMultiTracker.IsEnabled = btnStartTimer.IsEnabled = true;
                btnMultipleId.IsEnabled = false;
            };

            // 2. For a group of users, a dictionary is used, this should be provided after the unique ID

            btnMultipleId.Clicked += delegate
            {
                var extraInformation = new Dictionary<string,string>
                {
                    { "Email","alan_user@xamarin.com" },
                    { "Name", "Alan James User" },
                };
                Insights.Identify("UniqueUserId", extraInformation);
                btnCrashApp.IsEnabled = btnDivByZero.IsEnabled = btnFileException.IsEnabled = btnNullRef.IsEnabled = btnPartialInfo.IsEnabled = btnStartMultiTracker.IsEnabled = btnStartTimer.IsEnabled = true;
                btnSingle.IsEnabled = false;
            };

            // to make the Insights reporting tool report, an exception has to be thrown
            // the reports can be sent via one of three ways
            // the simplest is to just send back the exception

            btnDivByZero.Clicked += delegate
            {
                try
                {
                    int divByZero = 42 / int.Parse("0");
                }
                catch (DivideByZeroException ex)
                {
                    Insights.Report();
                }
            };


            // the next is to send specific information. This can achieved using a Dictionary<string,string>()
            // and may be constructed as part of the report or outside of it

            // 1. as part of the exception

            btnFileException.Clicked += async delegate
            {
                try
                {
                    var text = await rootFolder.GetFileAsync("some_file.tardis");
                    Debug.WriteLine("{0}", text.Path);
                }
                catch (FileNotFoundException ex)
                {
                    Insights.Report(ex, new Dictionary<string,string>
                        {
                            { "File missing", "some_file.tardis" },
                            { "Source file","MainActivity.cs" },
                            { "Method name", "protected override void OnCreate(Bundle bundle)" }
                        });
                }
            };

            // 2. outside the exception. Essentially, this is the same as the 1st type, but there is additional flexibility
            // Here it calls CreateDictionary which takes a T exception and produces a new dictionary from it
            // This is a very trivial example - data from Reflection would probably be of more use

            btnNullRef.Clicked += delegate
            {
                try
                {
                    List<string> myList = null;
                    myList.Add("Hello");
                }
                catch (NullReferenceException ex)
                {
                    var report = CreateDictionary(ex);
                    Insights.Report(ex, report);
                }
            };

            // 3. Instead of sending over the full exception, just send a piece over

            btnPartialInfo.Clicked += async delegate
            {
                try
                {
                    var block = new byte[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    var file = await rootFolder.CreateFileAsync(@"/bin/hello.txt", CreationCollisionOption.OpenIfExists);
                    await file.WriteAllTextAsync(block.ToString());
                }
                catch (IOException ex)
                {
                    // see http://msdn.microsoft.com/en-us/library/system.exception.data%28v=vs.110%29.aspx for more details on this
                    ex.Data["MoreData"] = "You can't write to the bin directory!";
                    // send the report
                    Insights.Report(ex);
                    // throw the exception - this exception would need to be caught using another try/catch
                    throw ex;
                }
            };

            // catching an uncaught exception
            btnCrashApp.Clicked += delegate
            {
                var block = new byte[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                block[11] = 10;
            };


            // An important aspect of any form of trace software is the ability to track an event. In the following example.
            // a simple reaction time will be measured.

            btnStartTimer.Clicked += delegate
            {
                btnStartTimer.Text = "Stop the clock";
                var timer = Stopwatch.StartNew(); // from System.Diagnostics
                btnStartTimer.Clicked += delegate
                {
                    using (var react = Insights.TrackTime("reactionTime"))
                    {
                        btnStartTimer.Clicked += async delegate
                        {
                            timer.Stop();
                            var timeSpan = timer.Elapsed;
                            await StoreReactionTime(DateTime.Now.Subtract(timeSpan).Second);
                        };
                    }
                };
            };

            // it is also possible to track a specific thread. There are two ways to do this - with and without additional parameters

            btnStartMultiTracker.Clicked += delegate
            {
                Insights.Track("mySpecificProcess");
                // In a similar way to using Debug.WriteLine, a dictionary can be used to track 
                Insights.Track("setUpForEach", new Dictionary<string,string>{ { "process1","create list" }, { "process2","populate list" } });
                var myList = new List<string>();
                myList.AddRange(new string[]{ "iOS", "Android", "Symbian", "Windows Mobile", "Blackberry" });

                // The next part is to do some work on the list. This will be a mix of TrackTimer and Track
                Insights.Track("doSomeWorkOnList", new Dictionary<string, string>{ { "process3", "encrypt and time data" } });
                var timer = Stopwatch.StartNew();
                using (var handle = Insights.TrackTime("encrypter"))
                {
                    EncryptData(myList);
                    WorkCompleted.Change += async delegate(object s, WorkCompletedEventArgs ea)
                    {
                        if (ea.ModuleName == "Encryption")
                        {
                            timer.Stop();
                            var timeSpan = timer.Elapsed;
                            await StoreReactionTime(DateTime.Now.Subtract(timeSpan).Second);
                        }
                    };
                }
                // tell the tracker we're done
                Insights.Track("mySpecificProcess", new Dictionary<string,string>{ { "process4", "processing completed" } });
            };

            return content;
        }

        private Dictionary<string,string> CreateDictionary<T>(T ex) where T : Exception
        {
            // this is an example of creating the dictionary based on a generic exception
            var myReport = new Dictionary<string,string> { { "Stack trace", ex.StackTrace }, { "Report", DateTime.Now.ToString() }, { "Message", ex.Message } };
            return myReport;
        }

        private void EncryptData(List<string> data)
        {
            // a very simple MD5 encryption of the data we've fed in. It shouldn't take any time at all really

            var encrypted = new List<string>();
            foreach (var d in data)
                using (var md5Hash = MD5.Create())
                    encrypted.Add(GetMd5Hash(md5Hash, d));

            // broadcast the event for tracking
			if (WorkCompleted != null)
	            WorkCompleted.BroadcastIt("Encryption");
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }

        private async Task<bool> StoreReactionTime(int time)
        {
            var file = await rootFolder.CreateFileAsync("testfile.txt", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(string.Format("Time taken = {0} seconds", time));
            Insights.Track("reactionTime", new Dictionary<string,string>{ { "Time taken", time.ToString() } });

            return true;
        }
    }
}

