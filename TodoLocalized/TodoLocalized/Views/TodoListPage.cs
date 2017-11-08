using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TodoLocalized.Resx;

namespace TodoLocalized
{
	public class TodoListPage : ContentPage
	{
		ListView listView;
		public TodoListPage ()
		{
			Title = AppResources.ApplicationTitle; // "Todo";

			listView = new ListView { RowHeight = 40 };
			listView.ItemTemplate = new DataTemplate (typeof (TodoItemCell));

			listView.ItemSelected += (sender, e) => {
				var todoItem = (TodoItem)e.SelectedItem;

				// use C# localization
				var todoPage = new TodoItemPage();

				// use XAML localization
//				var todoPage = new TodoItemXaml();


				todoPage.BindingContext = todoItem;
				Navigation.PushAsync(todoPage);
			};

			var layout = new StackLayout();
			if (Device.RuntimePlatform == Device.WinPhone) { // WinPhone doesn't have the title showing
				layout.Children.Add (new Label {
					Text = "Todo",
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
				});
			}
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;


			var tbiAdd = new ToolbarItem("Add", "plus.png", () =>
				{
					var todoItem = new TodoItem();
					var todoPage = new TodoItemPage();
					todoPage.BindingContext = todoItem;
					Navigation.PushAsync(todoPage);
				}, 0, 0);


			ToolbarItems.Add (tbiAdd);


			var tbiSpeak = new ToolbarItem ("Speak", "chat.png", () => {
				var todos = App.Database.GetItemsNotDone();
				var tospeak = "";
				foreach (var t in todos)
					tospeak += t.Name + " ";
				if (tospeak == "") tospeak = "there are no tasks to do";

				if (todos.Any ()) {
					var s = L10n.Localize ("SpeakTaskCount", "Number of tasks to do");
					tospeak = String.Format (s, todos.Count ()) + tospeak;
				}

				DependencyService.Get<ITextToSpeech>().Speak(tospeak);
			}, 0, 0);
			ToolbarItems.Add (tbiSpeak);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			listView.ItemsSource = App.Database.GetItems ();
		}
	}
}
