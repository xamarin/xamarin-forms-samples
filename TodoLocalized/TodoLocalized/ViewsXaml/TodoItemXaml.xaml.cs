using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Todo
{	
	public partial class TodoItemXaml : ContentPage
	{	
		public TodoItemXaml ()
		{
			InitializeComponent ();
		}

		void OnSave (object s, EventArgs e) {
			var todoItem = (TodoItem)BindingContext;
			App.Database.SaveItem(todoItem);
			this.Navigation.PopAsync();
		}
		void OnDelete (object s, EventArgs e) {
			var todoItem = (TodoItem)BindingContext;
			App.Database.DeleteItem(todoItem.ID);
			this.Navigation.PopAsync();
		}
		void OnCancel (object s, EventArgs e) {
			this.Navigation.PopAsync();
		}
		void OnSpeak (object s, EventArgs e) {
			var todoItem = (TodoItem)BindingContext;
			DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
		}
	}
}

