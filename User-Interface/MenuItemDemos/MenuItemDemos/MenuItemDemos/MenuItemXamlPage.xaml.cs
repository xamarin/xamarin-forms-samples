using MenuItemDemos.Services;
using System;

using Xamarin.Forms;

namespace MenuItemDemos
{
    public partial class MenuItemXamlPage : ContentPage
    {
        public MenuItemXamlPage()
        {
            InitializeComponent();

            listView.ItemsSource = DataService.GetListItems();
        }

        void OnDeleteClicked(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            messageLabel.Text = $"Delete handler was called on {item.BindingContext}";
        }

        void OnEditClicked(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            messageLabel.Text = $"Edit handler was called on {item.BindingContext}";
        }
    }
}