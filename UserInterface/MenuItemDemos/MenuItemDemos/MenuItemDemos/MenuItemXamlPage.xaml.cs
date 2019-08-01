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

        void DeleteClicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            messageLabel.Text = $"Delete handler was called on {item.BindingContext}";
        }

        void EditClicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            messageLabel.Text = $"Edit handler was called on {item.BindingContext}";
        }
    }
}