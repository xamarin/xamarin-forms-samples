using System;
using EmployeeDirectory;
using Xamarin.Forms;

namespace EmployeeDirectoryCSharp
{
	public static class App
	{
		public static IDirectoryService Service { get; set; }

		public static IPhoneFeatureService PhoneFeatureService { get; set; }

		public static DateTime LastUseTime { get; set; }

		public static Page GetMainPage ()
		{
			Service = MemoryDirectoryService.FromCsv ("XamarinDirectory.csv").Result;

			var employeeListView = new EmployeeListView ();
			var mainNav = new NavigationPage (employeeListView);
			return mainNav;
		}
	}
}

