using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InsightsXamarinFormsTest
{
	public class TrackViewModel
	{
		private int numReports = 0;
		private int numTracks = 0;

		public TrackViewModel ()
		{
			TrackCommand = new Command(Track);
			WarnCommand = new Command(Warn);
			ErrorCommand = new Command(Error);
			CrashCommand = new Command(Crash);
			IdentifyCommand = new Command(Identify);
		}

		/// <summary>
		/// Sends a Track to Xamarin.Insights
		/// </summary>
		public Command TrackCommand { get; set; }

		/// <summary>
		/// Sends a Report to Xamarin.Insights with Severity.Warning
		/// </summary>
		public Command WarnCommand { get; set; }

		/// <summary>
		/// Sends a Report to Xamarin.Insights with Severity.Error
		/// </summary>
		public Command ErrorCommand { get; set; }

		/// <summary>
		/// Crash the application
		/// </summary>
		public Command CrashCommand { get; set; }

		/// <summary>
		/// Identify the current user/session in Xamarin.Insights
		/// </summary>
		public Command IdentifyCommand { get; set; }

		private void Track ()
		{
			numTracks += 1;

			Xamarin.Insights.Track(string.Format("Track {0}", numTracks), new Dictionary <string, string> { 
				{"track-local-time", DateTime.Now.ToString()}
			});

			MessagingCenter.Send<TrackViewModel, string>(this, "Alert", "Track registered");
		}

		private void Warn ()
		{
			try {
				numReports += 1;

				// Create a collection container to hold exceptions
				List<Exception> exceptions = new List<Exception>();

				// We have an exception with an innerexception, so add it to the list
				exceptions.Add(new TimeoutException("This is part 1 of aggregate exception", new ArgumentException("ID missing")));

				// Another exception, add to list
				exceptions.Add(new NotImplementedException("This is part 2 of aggregate exception"));

				// All done, now create the AggregateException and throw it
				AggregateException aggEx = new AggregateException(exceptions);
				throw aggEx;
			} catch(Exception exp) {
				Xamarin.Insights.Report(exp, new Dictionary <string, string> { 
					{"warning-local-time", DateTime.Now.ToString()}
				}, Xamarin.Insights.Severity.Warning);

				MessagingCenter.Send<TrackViewModel, string>(this, "Alert", "Warning registered");
			}
		}

		private void Error ()
		{
			try {
				numReports += 1;
				throw new NotSupportedException(string.Format("Oh no. Really bad stuff happened.", numReports));
			} catch(Exception exp) {
				Xamarin.Insights.Report(exp, new Dictionary <string, string> { 
					{"error-local-time", DateTime.Now.ToString()}
				}, Xamarin.Insights.Severity.Error);

				MessagingCenter.Send<TrackViewModel, string>(this, "Alert", "Error registered");
			}
		}

		private void Crash ()
		{
			throw new Exception("Unhandled Exception that crashed your app.");
		}

		private void Identify ()
		{
			// Identify the user (normally done during Login, etc. and not on button touches)
			Xamarin.Insights.Identify ("1234567890", new Dictionary <string, string> { 
				{Xamarin.Insights.Traits.Email, "your@email.com"},
				{Xamarin.Insights.Traits.Name, "John Doe"},
				{"Title", "Code Monkey"}
			});

			MessagingCenter.Send<TrackViewModel, string>(this, "Alert", "Identify registered");
		}
	}
}

