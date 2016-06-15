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

		void OnAddItemClicked (object sender, EventArgs e)
		{
			var todoPage = new TodoItemPage ();
			todoPage.BindingContext = new TodoItem ();
			Navigation.PushAsync (todoPage);
		}

		async void OnLogoutClicked (object sender, EventArgs e)
		{
			await App.TodoManager.LogoutAsync ();
			Navigation.InsertPageBefore (new LoginPage (), this);
			Navigation.PopAsync ();
		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var todoPage = new TodoItemPage ();
			todoPage.BindingContext = e.SelectedItem as TodoItem;
			Navigation.PushAsync (todoPage);
		}
	}
}
