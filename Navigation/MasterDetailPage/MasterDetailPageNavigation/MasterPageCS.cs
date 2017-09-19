using System.Collections.Generic;
using Xamarin.Forms;

namespace MasterDetailPageNavigation
{
    public class MasterPageCS : ContentPage
    {
        public ListView ListView { get { return listView; } }

        ListView listView;

        public MasterPageCS()
        {
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Contacts",
                IconSource = "contacts.png",
                TargetType = typeof(ContactsPageCS)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "TodoList",
                IconSource = "todo.png",
                TargetType = typeof(TodoListPageCS)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Reminders",
                IconSource = "reminders.png",
                TargetType = typeof(ReminderPageCS)
            });

            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid { Padding = new Thickness(5, 10) };
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    var image = new Image();
                    image.SetBinding(Image.SourceProperty, "IconSource");
                    var label = new Label { VerticalOptions = LayoutOptions.FillAndExpand };
                    label.SetBinding(Label.TextProperty, "Title");

                    grid.Children.Add(image);
                    grid.Children.Add(label, 1, 0);

                    return new ViewCell { View = grid };
                }),
                SeparatorVisibility = SeparatorVisibility.None
            };

            Icon = "hamburger.png";
            Title = "Personal Organiser";
            Padding = new Thickness(0, 40, 0, 0);
            Content = new StackLayout
            {
                Children = { listView }
            };
        }
    }
}
