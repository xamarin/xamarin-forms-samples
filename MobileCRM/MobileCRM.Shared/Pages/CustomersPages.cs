using MobileCRM.Shared.ViewModels;
using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MobileCRM.Shared.CustomViews;
using MobileCRM.Models;

namespace MobileCRM.Shared.Pages
{
    public class CustomersPages : ContentPage
    {
        private ContactsViewModel ViewModel
        {
            get { return BindingContext as ContactsViewModel; }
        }

        public CustomersPages()
        {
            BindingContext = new ContactsViewModel();

            this.SetBinding(Page.TitleProperty, "Title");
            this.SetBinding(Page.IconProperty, "Icon");

            var list = new ListView();
            list.ItemsSource = ViewModel.Models;

#if __ANDROID__
            var cell = new DataTemplate(typeof(ListTextCell));
#else
            var cell = new DataTemplate(typeof(TextCell));
#endif

            
            cell.SetBinding(TextCell.TextProperty, "FirstName");
            cell.SetBinding(TextCell.DetailProperty, "Industry");

            list.ItemTemplate = cell;
            list.ItemSelected += (sender, e) =>
            {
                var details = new ContactDetailPage(e.SelectedItem as IContact);
                Navigation.PushAsync(details);
            };
            var stack = new StackLayout();
            stack.Children.Add(list);
            Content = stack;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(ViewModel.Models.Count == 0)
                ViewModel.LoadModelsCommand.Execute(null);
        }
    }
}
