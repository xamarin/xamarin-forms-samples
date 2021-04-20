using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UsingUITest.UITests
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if(platform == Platform.Android)
			{
				return ConfigureApp
					.Android
					.InstalledApp("com.xamarin.usinguitest")
					.StartApp();
			}

			return ConfigureApp
				.iOS
				.StartApp();
		}
	}
}

