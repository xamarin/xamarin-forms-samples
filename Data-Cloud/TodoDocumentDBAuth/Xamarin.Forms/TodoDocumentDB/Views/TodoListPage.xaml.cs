using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoDocumentDB
{
	public partial class TodoListPage : ContentPage
	{
		bool isLoggingIn = false;
		bool isLoggedIn = false;

		public TodoListPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (!isLoggingIn && !isLoggedIn)
			{
				isLoggingIn = true;
				isLoggedIn = await App.TodoManager.LoginAsync(this);
				isLoggingIn = false;
			}

			if (isLoggedIn)
			{
				await RefreshData();
			}
		}

		async Task RefreshData()
		{
			Exception error = null;

			try
			{
				listView.ItemsSource = await App.TodoManager.GetTodoItemsAsync();
			}
			catch (Exception ex)
			{
				error = ex;
			}

			if (error != null)
			{
				await DisplayAlert("Error", "Unable to refresh data", "OK");
			}
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
