using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DeepLinking
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
            //Xamarin forms Previewer test
            if (DesignMode.IsDesignModeEnabled)
            {
                listView.ItemsSource = new List<TodoItem>()
                {
                    new TodoItem(){Done=false,ID="2",Name="list-1",Notes="Note-1"},
                };
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Xamarin forms Previewer test
            if (DesignMode.IsDesignModeEnabled)
            {
                listView.ItemsSource = new List<TodoItem>()
                {
                    new TodoItem(){Done=false,ID="2",Name="list-1",Notes="Note-1"},
                };
            }
            else
            {
                listView.ItemsSource = App.Database.GetItems();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            listView.ItemsSource = null;
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            var todoItem = new TodoItem()
            {
                ID = Guid.NewGuid().ToString()
            };
            var todoPage = new TodoItemPage(true)
            {
                BindingContext = todoItem
            };
            await Navigation.PushAsync(todoPage);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = e.SelectedItem as TodoItem;
            var todoPage = new TodoItemPage
            {
                BindingContext = todoItem
            };
            await Navigation.PushAsync(todoPage);
        }
    }
}

