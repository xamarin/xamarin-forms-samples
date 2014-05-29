using System;
using EmployeeDirectory;
using Xamarin.Forms;
using EmployeeDirectoryUI.CSharp;
using EmployeeDirectoryUI.Xaml;
using System.Threading.Tasks;

namespace EmployeeDirectoryUI
{
	public enum UIImplementation
	{
		CSharp = 0,
		Xaml
	}

	public static class App
	{
		//Change the following line to switch between XAML and C# versions
		private UIImplementation uiImplementation = UIImplementation.CSharp;

		public static IDirectoryService Service { get; set; }

		public static IPhoneFeatureService PhoneFeatureService { get; set; }

		public static DateTime LastUseTime { get; set; }

		public static Page GetMainPage ()
		{
			Service = MemoryDirectoryService.FromCsv ("XamarinDirectory.csv").Result;

			var employeeList = new ContentPage ();
			if (uiImplementation == UIImplementation.CSharp) {
				employeeList = new EmployeeListView ();
			} else if (uiImplementation == UIImplementation.Xaml) {
				employeeList = new EmployeeListXaml ();
			}

			return new NavigationPage (employeeList);
		}
	}
}

