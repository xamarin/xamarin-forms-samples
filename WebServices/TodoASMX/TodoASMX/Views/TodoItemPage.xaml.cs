using System;
using Xamarin.Forms;

namespace TodoASMX
{
	public partial class TodoItemPage : ContentPage
	{
		bool isNewItem;

		public TodoItemPage (bool isNew = false)
		{
			InitializeComponent ();
			isNewItem = isNew;
		}

		async void OnSaveActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.SaveTodoItemAsync (todoItem, isNewItem);
			await Navigation.PopAsync ();
		}

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.DeleteTodoItemAsync (todoItem);
			await Navigation.PopAsync ();
		}

		async void OnCancelActivated (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}

		void OnSpeakActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			App.Speech.Speak (todoItem.Name + " " + todoItem.Notes);
		}
	}
}
