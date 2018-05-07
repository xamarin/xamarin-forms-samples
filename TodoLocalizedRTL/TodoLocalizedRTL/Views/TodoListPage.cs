using System;
using System.Linq;
using Xamarin.Forms;
using TodoLocalized.Resx;

namespace TodoLocalized
{
    public class TodoListPage : ContentPage
    {
        ListView listView;
        public TodoListPage()
        {
            FlowDirection = Device.FlowDirection;

            Title = AppResources.ApplicationTitle;

            listView = new ListView { RowHeight = 40 };
            listView.ItemTemplate = new DataTemplate(typeof(TodoItemCell));

            listView.ItemSelected += async (sender, e) =>
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = (TodoItem)e.SelectedItem
                });
            };

            var layout = new StackLayout { Margin = new Thickness(20) };
            layout.Children.Add(listView);
            Content = layout;

            var tbiAdd = new ToolbarItem("Add", "plus.png", () =>
                {
                    var todoItem = new TodoItem();
                    var todoPage = new TodoItemPage();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);

            ToolbarItems.Add(tbiAdd);

            var tbiSpeak = new ToolbarItem("Speak", "chat.png", () =>
            {
                var todos = App.Database.GetItemsNotDone();
                var tospeak = "";
                foreach (var t in todos)
                    tospeak += t.Name + " ";
                if (tospeak == "") tospeak = "there are no tasks to do";

                if (todos.Any())
                {
                    var s = L10n.Localize("SpeakTaskCount", AppResources.Culture);
                    tospeak = String.Format(s, todos.Count()) + tospeak;
                }

                DependencyService.Get<ITextToSpeech>().Speak(tospeak);
            }, 0, 0);
            ToolbarItems.Add(tbiSpeak);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.GetItems();
        }
    }
}

