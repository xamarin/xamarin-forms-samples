using System;
using EmployeeDirectory;
using Xamarin.Forms;
using EmployeeDirectoryUI.CSharp;
using EmployeeDirectoryUI.Xaml;
using System.Threading.Tasks;

namespace EmployeeDirectoryUI
{
	public enum FormsImplementation
	{
		CSharp = 0,
		Xaml
	}

	public static class App
	{
		public static IDirectoryService Service { get; set; }

		public static IPhoneFeatureService PhoneFeatureService { get; set; }

		public static DateTime LastUseTime { get; set; }

		public static Page GetMainPage (FormsImplementation uiVersion)
		{
			Service = MemoryDirectoryService.FromCsv ("XamarinDirectory.csv");

			var employeeList = new ContentPage ();
			if (uiVersion == FormsImplementation.CSharp) {
				employeeList = new EmployeeListView ();
			} else if (uiVersion == FormsImplementation.Xaml) {
				employeeList = new EmployeeListXaml ();
			}

			return new NavigationPage (employeeList);
		}
	}
}

