using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;
using System.Threading.Tasks;
using System.Linq;

namespace EmployeeDirectory
{
	public static class App
	{
		/// <summary>
		/// service used to supply data to the app
		/// </summary>
		/// <remarks>
		/// * Memory (uses CSV file)
		/// * LDAP (requires network)
		/// </remarks>
		public static IDirectoryService Service;

		public static IPhoneFeatureService PhoneFeatureService;

		/// <summary>
		/// last time the device was used
		/// </summary>
		public static DateTime LastUseTime { get; set; }

		public static Page GetMainPage ()
		{
			//
			// Create the service
			//

			//
			// Local CSV file
			Service = MemoryDirectoryService.FromCsv ("XamarinDirectory.csv").Result;

			//
			// LDAP service - uncomment to try it out.
			//Service = new LdapDirectoryService {
			//	Host = "ldap.mit.edu",
			//	SearchBase = "dc=mit,dc=edu",
			//};

			var employeeList = new EmployeeListXaml ();

			var mainNav = new NavigationPage (employeeList);

			return mainNav;
		}
	}
}

