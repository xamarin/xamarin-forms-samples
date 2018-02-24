using System;
using Xamarin.Forms;

namespace Todo
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
			listView.ItemsSource = await App.TodoManager.GetAllItemsAsync();
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				TodoItem = new TodoItem()
			});
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				TodoItem = e.SelectedItem as TodoItem
			});
		}

		async void OnRateApplication(object sender, EventArgs e)
		{
            // The xaml file of ReteAppPage doesn't conatin any image and label control. 
            // I have to empty this tool button handler. I hope original author can fix this issue.
		 	// await Navigation.PushAsync(new RateAppPage());
		}
	}
}
