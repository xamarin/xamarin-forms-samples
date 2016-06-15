using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace InsightsXamarinFormsTest
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// Initialize Insights
			Xamarin.Insights.Initialize(Constants.INSIGHTS_API_KEY);

			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

