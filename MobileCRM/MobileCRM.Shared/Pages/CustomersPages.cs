using MobileCRM.Shared.ViewModels;
using MobileCRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MobileCRM.Shared.CustomViews;

namespace MobileCRM.Shared.Pages
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

#if __ANDROID__
            var cell = new DataTemplate(typeof(ListTextCell));
#else
            var cell = new DataTemplate(typeof(TextCell));
#endif

            
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
