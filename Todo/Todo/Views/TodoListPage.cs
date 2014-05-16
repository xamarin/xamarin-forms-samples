using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo
{
	public class TodoListPage : ContentPage
	{
		ListView listView;
		public TodoListPage ()
		{
			Title = "Todo";

			NavigationPage.SetHasNavigationBar (this, true);

			listView = new ListView {
			    RowHeight = 40
			};
			listView.ItemTemplate = new DataTemplate (typeof (TodoItemCell));

//			listView.ItemSource = new string [] { "Buy pears", "Buy oranges", "Buy mangos", "Buy apples", "Buy bananas" };
//			listView.ItemSource = new TodoItem [] { 
//				new TodoItem {Name = "Buy pears`"}, 
//				new TodoItem {Name = "Buy oranges`", Done=true},
//				new TodoItem {Name = "Buy mangos`"}, 
//				new TodoItem {Name = "Buy apples`", Done=true},
//				new TodoItem {Name = "Buy bananas`", Done=true}
//			};

			// HACK: workaround issue #894 for now
			if (Device.OS == TargetPlatform.iOS)
				listView.ItemSource = new string [1] {""};

			listView.ItemSelected += (sender, e) => {
				var todoItem = (TodoItem)e.Data;
				var todoPage = new TodoItemPage();
				todoPage.BindingContext = todoItem;
				Navigation.Push(todoPage);
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {listView}
			};

			var tbi = new ToolbarItem ("+", null, () => {
				var todoItem = new TodoItem();
				var todoPage = new TodoItemPage();
				todoPage.BindingContext = todoItem;
				Navigation.Push(todoPage);
			}, 0, 0);
			if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
				tbi = new ToolbarItem ("+", "plus", () => {
					var todoItem = new TodoItem();
					var todoPage = new TodoItemPage();
					todoPage.BindingContext = todoItem;
					Navigation.Push(todoPage);
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
					App.Speech.Speak(tospeak);
				}, 0, 0);
				ToolbarItems.Add (tbi2);
			}

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			listView.ItemSource = App.Database.GetItems ();
		}
	}
}

