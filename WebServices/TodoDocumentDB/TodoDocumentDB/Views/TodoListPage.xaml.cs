using System;
using Xamarin.Forms;

namespace TodoDocumentDB
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

			await App.TodoManager.CreateDatabase(Constants.DatabaseName);
			await App.TodoManager.CreateDocumentCollection(Constants.DatabaseName, Constants.CollectionName);
			listView.ItemsSource = await App.TodoManager.GetTodoItemsAsync();
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage(true)
			{
				BindingContext = new TodoItem
				{
					Id = Guid.NewGuid().ToString()
				}
			});
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as TodoItem
			});
		}
	}
}
