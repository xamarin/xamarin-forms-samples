using System;
using Xamarin.Forms;

namespace TodoParse
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage ()
		{
			InitializeComponent ();
		}
			
		protected async override void OnAppearing ()
		{
			base.OnAppearing ();
			listView.ItemsSource = await App.TodoManager.GetTasksAsync ();
		}

		void OnAddItemActivated(object sender, EventArgs e) {
			var todoItem = new TodoItem ();
			var todoPage = new TodoItemPage ();
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync (todoPage);
		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {
			var todoItem = e.SelectedItem as TodoItem;
			var todoPage = new TodoItemPage();
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync(todoPage);
		}
	}
}
