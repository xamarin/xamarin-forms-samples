using Xamarin.Forms;

namespace TodoLocalized
{
    public class TodoListPage : ContentPage
    {
        ListView listView;

        public TodoListPage()
        {
            Title = AppResources.ApplicationTitle; // "Todo";

            NavigationPage.SetHasNavigationBar(this, true);

            listView = new ListView
            {
                RowHeight = 40,
                ItemTemplate = new DataTemplate(typeof(TodoItemCell))
            };

            listView.ItemSelected += (sender, e) =>
            {
                var todoItem = (TodoItem)e.SelectedItem;
                var todoPage = new TodoItemPage();
                todoPage.BindingContext = todoItem;
                Navigation.PushAsync(todoPage);
            };

            var layout = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand };
            layout.Children.Add(listView);
            Content = layout;

            ToolbarItem tbi = null;
            if (Device.RuntimePlatform == Device.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    var todoItem = new TodoItem();
                    var todoPage = new TodoItemPage();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);
            }
            if (Device.RuntimePlatform == Device.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var todoItem = new TodoItem();
                    var todoPage = new TodoItemPage();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);
            }

            ToolbarItems.Add(tbi);

            if (Device.RuntimePlatform == Device.iOS)
            {
                var tbi2 = new ToolbarItem("?", null, () =>
                {
                    var todos = App.Database.GetItemsNotDone();
                    var tospeak = "";
                    foreach (var t in todos)
                        tospeak += t.Name + " ";
                    if (tospeak == "")
                        tospeak = "there are no tasks to do";

                    DependencyService.Get<ITextToSpeech>().Speak(tospeak);
                }, 0, 0);
                ToolbarItems.Add(tbi2);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.GetItems();
        }
    }
}
