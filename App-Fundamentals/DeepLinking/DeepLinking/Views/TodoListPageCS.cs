using System;
using Xamarin.Forms;

namespace DeepLinking
{
    public partial class TodoListPageCS : ContentPage
    {
        ListView listView;

        public TodoListPageCS()
        {
            var toolbarItem = new ToolbarItem { Text = "+" };
            toolbarItem.Clicked += OnAddItemClicked;
            ToolbarItems.Add(toolbarItem);

            var dataTemplate = new DataTemplate(() =>
            {
                var label = new Label { HorizontalOptions = LayoutOptions.StartAndExpand, VerticalTextAlignment = TextAlignment.Center };
                label.SetBinding(Label.TextProperty, "Name");

                var image = new Image { Source = ImageSource.FromFile("check.png"), HorizontalOptions = LayoutOptions.End };
                image.SetBinding(VisualElement.IsVisibleProperty, "Done");

                var stackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        label,
                        image
                    }
                };

                return new ViewCell { View = stackLayout };
            });

            listView = new ListView { ItemTemplate = dataTemplate, Margin = new Thickness(20) };
            listView.ItemSelected += OnItemSelected;

            Title = "Todo";
            Content = listView;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            listView.ItemsSource = null;
        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}
