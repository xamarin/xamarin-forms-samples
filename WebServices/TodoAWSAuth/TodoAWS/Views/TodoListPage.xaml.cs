using System;
using Xamarin.Forms;
using System.Linq;

namespace TodoAWSSimpleDB
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

		async void OnLogoutClicked (object sender, EventArgs e)
		{
			DependencyService.Get<IAuthentication> ().Logout ();
			Navigation.InsertPageBefore (new LoginPage (), Navigation.NavigationStack.First ());
			await Navigation.PopToRootAsync ();
		}

		void OnAddItemClicked (object sender, EventArgs e)
		{
			var todoItem = new TodoItem () {
				ID = Guid.NewGuid ().ToString (),
				Notes = string.Empty
			};
			var todoPage = new TodoItemPage ();
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync (todoPage);
		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var todoItem = e.SelectedItem as TodoItem;
			var todoPage = new TodoItemPage ();
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync (todoPage);
		}
	}
}
