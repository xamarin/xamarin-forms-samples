using System;
using Xamarin.Forms;

namespace TodoASMX
{
    public partial class TodoListPage : ContentPage
    {

        public TodoListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.TodoManager.GetTodoItemsAsync();
        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            var todoItem = new TodoItem()
            {
                ID = Guid.NewGuid().ToString()
            };
            var todoPage = new TodoItemPage(true);
            todoPage.BindingContext = todoItem;
            await Navigation.PushAsync(todoPage);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = e.SelectedItem as TodoItem;
            var todoPage = new TodoItemPage();
            todoPage.BindingContext = todoItem;
            await Navigation.PushAsync(todoPage);
        }
    }
}
