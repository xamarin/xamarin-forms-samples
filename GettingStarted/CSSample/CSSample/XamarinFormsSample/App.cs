using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;

using XamarinFormsSample.Model;
using XamarinFormsSample.Views;

namespace XamarinFormsSample
{
	public class App : Application
    {
        static ObservableCollection<Employee> _employees;

        public static bool IsLoggedIn { get; set; }

        /// <summary>
        ///   Hard coded list of employees.
        /// </summary>
        /// <value>The employees.</value>
        public static ObservableCollection<Employee> Employees
        {
            get
            {
                if (_employees != null)
                {
                    return _employees;
                }
                List<Employee> list = new List<Employee>
                                      {
                                          new Employee { FirstName = "Cecil", LastName = "Kinross", ImageUri = "CecilKinross.png" },
                                          new Employee { FirstName = "William", LastName = "Hall", ImageUri = "WilliamHall.png" },
                                          new Employee { FirstName = "Robert", LastName = "Spall", ImageUri = "RobertSpall.png" },
                                          new Employee { FirstName = "Ernest", LastName = "Smith", ImageUri = "ErnestSmith.png" },
                                          new Employee { FirstName = "Paul", LastName = "Triquet", ImageUri = "PaulTriquet.png" }
                                      };

                int counter = 1;
                foreach (Employee employee in list)
                {
                    employee.Twitter = "@fake" + counter++;
                }
                _employees = new ObservableCollection<Employee>(list.OrderBy(e => e.LastName));
                return _employees;
            }
        }

        /// <summary>
        ///   Returns the startup page.
        /// </summary>
        /// <returns>The main page.</returns>
		public App ()
        {
            NavigationPage mainNav = new NavigationPage(new EmployeeListPage());
            MainPage = mainNav;
        }
    }
}
