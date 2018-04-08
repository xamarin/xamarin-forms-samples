using System.Collections.ObjectModel;

using Xamarin.Forms;

using XamarinFormsSample.Model;
using System.Threading.Tasks;
using System;

namespace XamarinFormsSample.Views
{
    /// <summary>
    ///   This page will display a list of employees.
    /// </summary>
    class EmployeeListPage : ContentPage
    {
        ListView _employeeList;
        ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        ToolbarItem _loginToolbarButton;

        public EmployeeListPage()
        {
            LoadEmployeesForDisplay();
            Title = "Employee List";

            CreateLoginToolbarButton();
            CreateEmployeeListView();

            Content = _employeeList;
        }

        void CreateLoginToolbarButton()
        {
            if (_loginToolbarButton != null)
            {
                return;
            }

            // There is a bug with Android which prevents the use of null for the iconName.
            string iconName = Device.RuntimePlatform == Device.Android ? "ic_action_content_new.png" : null;
            _loginToolbarButton = new ToolbarItem("Login", iconName, async () => {
                                                                         ToolbarItems.Remove(_loginToolbarButton);
                                                                         await  Navigation.PushAsync(new LoginPage());
                                                                     });
        }



        void LoadEmployeesForDisplay()
        {
            if (App.IsLoggedIn)
            {
                if (_employees.Count == 0)
                {
                    _employees = App.Employees;
                }
            }
        }

        void CreateEmployeeListView()
        {
            _employeeList = new ListView
                            {
                                RowHeight = 50,
                                ItemTemplate = new DataTemplate(typeof(EmployeeCell))
                            };
            _employeeList.ItemSelected  += EmployeeListOnItemSelected;
        }

        /// <summary>
        ///   This method is invoked when the user selects an employee. Will open up the EmployeeDetailsPage for that employee.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="eventArg">Event argument.</param>
        async void EmployeeListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItem == null)
            {
                return;
            }

            await Navigation.PushAsync(new EmployeeDetailPage((Employee)e.SelectedItem));
            listView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            // This method is invoked by Xamarin.Forms at some point when the
            // page is being displayed.
            base.OnAppearing();
            LoadEmployeesForDisplay();
            _employeeList.ItemsSource = _employees;

            if (App.IsLoggedIn)
            {
                // Don't have to do anything.
            }
            else
            {
                ToolbarItems.Add(_loginToolbarButton);
            }
        }
    }
}
