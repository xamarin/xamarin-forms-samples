using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace Todo
{
	public class TodoListPage : ContentPage
	{
		ListView listView;
		public TodoListPage ()
		{
			Title = "Todo";

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
					(typeof (TodoItemCell));
			listView.ItemSelected += (sender, e) => {
				var todoItem = (TodoItem)e.SelectedItem;
				var todoPage = new TodoItemPage();
				todoPage.BindingContext = todoItem;

				((App)App.Current).ResumeAtTodoId = todoItem.ID;
				Debug.WriteLine("setting ResumeAtTodoId = " + todoItem.ID);

				Navigation.PushAsync(todoPage);
			};

			var layout = new StackLayout();
			if (Device.OS == TargetPlatform.WinPhone) { // WinPhone doesn't have the title showing
				layout.Children.Add(new Label{
					Text="Todo", 
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))});
			}
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			#region toolbar
			ToolbarItem tbi = null;
			if (Device.OS == TargetPlatform.iOS)
			{
				tbi = new ToolbarItem("+", null, () =>
					{
						var todoItem = new TodoItem();
						var todoPage = new TodoItemPage();
						todoPage.BindingContext = todoItem;
						Navigation.PushAsync(todoPage);
					}, 0, 0);
			}
			if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
				tbi = new ToolbarItem ("+", "plus", () => {
					var todoItem = new TodoItem();
					var todoPage = new TodoItemPage();
					todoPage.BindingContext = todoItem;
					Navigation.PushAsync(todoPage);
				}, 0, 0);
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				tbi = new ToolbarItem("Add", "add.png", () =>
					{
						var todoItem = new TodoItem();
						var todoPage = new TodoItemPage();
						todoPage.BindingContext = todoItem;
						Navigation.PushAsync(todoPage);
					}, 0, 0);
			}

			ToolbarItems.Add (tbi);

			if (Device.OS == TargetPlatform.iOS) {
				var tbi2 = new ToolbarItem ("?", null, () => {
					var todos = App.Database.GetItemsNotDone();
					var tospeak = "";
					foreach (var t in todos)
						tospeak += t.Name + " ";
					if (tospeak == "") tospeak = "there are no tasks to do";

					DependencyService.Get<ITextToSpeech>().Speak(tospeak);
				}, 0, 0);
				ToolbarItems.Add (tbi2);
			}
			#endregion
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			// reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtTodoId = -1;
			listView.ItemsSource = App.Database.GetItems ();
		}
	}
}

