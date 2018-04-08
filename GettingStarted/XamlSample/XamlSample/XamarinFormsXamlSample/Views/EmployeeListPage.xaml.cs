using System;
using Xamarin.Forms;

using XamarinFormsSample.Model;

namespace XamarinFormsXamlSample.Views
{
    public partial class EmployeeListPage
    {
        ToolbarItem _loginToolbarItem;

        public EmployeeListPage()
        {
            InitializeComponent();
            listView.IsVisible = App.IsLoggedIn;

            string iconName = Device.RuntimePlatform == Device.UWP ||
                              Device.RuntimePlatform == Device.WinPhone ? "/Toolkit.Content/ApplicationBar.Add.png" : null;

            _loginToolbarItem = new ToolbarItem("Login", iconName, async () =>
            {
                ToolbarItems.Remove(_loginToolbarItem);
                await Navigation.PushAsync(new LoginPage());
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.IsVisible = App.IsLoggedIn;

            if (!App.IsLoggedIn)
            {
                ToolbarItems.Add(_loginToolbarItem);
            }
        }

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
    }
}
