using System;
using Xamarin.Forms;

namespace DeepLinking
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            listView.ItemsSource = null;
        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}

