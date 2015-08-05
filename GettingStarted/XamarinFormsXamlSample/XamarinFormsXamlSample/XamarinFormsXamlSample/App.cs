using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

using XamarinFormsSample.Model;
using XamarinFormsXamlSample.Views;

namespace XamarinFormsXamlSample
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
                if (_employees == null)
                {
                    string prefix = Device.OnPlatform("", "", "Images/");

                    List<Employee> list = new List<Employee>
                                          {
                                              new Employee { FirstName = "Cecil", LastName = "Kinross", ImageUri = prefix + "CecilKinross.png" },
                                              new Employee { FirstName = "William", LastName = "Hall", ImageUri = prefix + "WilliamHall.png" },
                                              new Employee { FirstName = "Robert", LastName = "Spall", ImageUri = prefix + "RobertSpall.png" },
                                              new Employee { FirstName = "Ernest", LastName = "Smith", ImageUri = prefix + "ErnestSmith.png" },
                                              new Employee { FirstName = "Paul", LastName = "Triquet", ImageUri = prefix + "PaulTriquet.png" }
                                          };

                    int counter = 1;
                    foreach (Employee employee in list)
                    {
                        employee.Twitter = "@fake" + counter++;
                    }
                    _employees = new ObservableCollection<Employee>(list.OrderBy(e => e.LastName));
                }
                return _employees;
            }
        }

        /// <summary>
        ///   Returns the startup page.
        /// </summary>
        /// <returns>The main page.</returns>
        public App()
        {
            NavigationPage mainNav = new NavigationPage(new EmployeeListPage());
            MainPage = mainNav;
        }
    }
}
