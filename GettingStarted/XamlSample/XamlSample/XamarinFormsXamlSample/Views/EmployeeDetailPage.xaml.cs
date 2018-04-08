using System;
using Xamarin.Forms;

using XamarinFormsSample.Model;

namespace XamarinFormsXamlSample.Views
{
    public partial class EmployeeDetailPage
    {
        public EmployeeDetailPage(Employee employee)
        {
            InitializeComponent();
            this.BindingContext = employee;
        }
        async void OnDeleteButtonClick(object sender, EventArgs e)
        {
            App.Employees.Remove(this.BindingContext as Employee);
            await Navigation.PopAsync();
        }

        async void OnSaveButtonClick(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
