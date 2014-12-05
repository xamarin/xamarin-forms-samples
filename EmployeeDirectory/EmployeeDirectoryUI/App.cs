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

	public class App : Application
	{
		//Change the following line to switch between XAML and C# versions
		private static UIImplementation uiImplementation = UIImplementation.CSharp;

		public static IDirectoryService Service { get; set; }

		public static IPhoneFeatureService PhoneFeatureService { get; set; }

		public static DateTime LastUseTime { get; set; }

		public App ()
		{
			var task = Task.Run(async () => { 
				Service = await MemoryDirectoryService.FromCsv("XamarinDirectory.csv"); 
			});
			task.Wait();

			var employeeList = new ContentPage ();
			if (uiImplementation == UIImplementation.CSharp) {
				employeeList = new EmployeeListView ();
			} else if (uiImplementation == UIImplementation.Xaml) {
				employeeList = new EmployeeListXaml ();
			}

			MainPage = new NavigationPage (employeeList);
		}
	}
}

