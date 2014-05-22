using Meetup.Shared.ViewModels;
using MobileCRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Meetup.Shared.Pages
{
    public class CustomersPages : ContentPage
    {
        private CustomersViewModel ViewModel
        {
            get { return BindingContext as CustomersViewModel; }
        }

        public CustomersPages()
        {
            BindingContext = new CustomersViewModel();

            this.SetBinding(Page.TitleProperty, "Title");
            this.SetBinding(Page.IconProperty, "Icon");

            var list = new ListView();
            list.ItemSource = ViewModel.Customers;
            list.BackgroundColor = Helpers.Color.Tan.ToFormsColor();

            var cell = new DataTemplate(typeof(TextCell));

            cell.SetValue(TextCell.TextColorProperty, Color.Black);
            cell.SetValue(TextCell.DetailColorProperty, Color.Gray);

            cell.SetBinding(TextCell.TextProperty, "DisplayLabel");
            cell.SetBinding(TextCell.DetailProperty, "DisplayCategory");

            list.ItemTemplate = cell;
            list.ItemSelected += (sender, e) =>
            {
                var details = new CustomerDetailPage(e.SelectedItem as POI);
                Navigation.PushAsync(details);
            };
            var stack = new StackLayout();
            stack.Children.Add(list);
            Content = stack;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(ViewModel.Customers.Count == 0)
                ViewModel.LoadCustomersCommand.Execute(null);
        }
    }
}
