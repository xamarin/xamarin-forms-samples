using System;
using Xamarin.Forms;

namespace DeepLinking
{
	public partial class TodoListPageCS : ContentPage
	{
		ListView listView;

		public TodoListPageCS()
		{
			Title = "Todo";

			var toolbarItem = new ToolbarItem { Text = "+" };
			toolbarItem.Clicked += OnAddItemClicked;
			toolbarItem.Icon = Device.RuntimePlatform == Device.Android ? "plus.png" : null;
			ToolbarItems.Add(toolbarItem);

			var dataTemplate = new DataTemplate(() =>
			{
				var label = new Label { VerticalTextAlignment = TextAlignment.Center };
				label.SetBinding(Label.TextProperty, "Name");

				var image = new Image { Source = ImageSource.FromFile("check.png") };
				image.SetBinding(VisualElement.IsVisibleProperty, "Done");

				var stackLayout = new StackLayout
				{
					Padding = new Thickness(20, 0, 0, 0),
					HorizontalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						label,
						image
					}
				};

				return new ViewCell { View = stackLayout };
			});

			listView = new ListView { ItemTemplate = dataTemplate };
			listView.ItemSelected += OnItemSelected;

			Content = listView;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			listView.ItemsSource = App.Database.GetItems();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			listView.ItemsSource = null;
		}

		async void OnAddItemClicked(object sender, EventArgs e)
		{
			var todoItem = new TodoItem()
			{
				ID = Guid.NewGuid().ToString()
			};
			var todoPage = new TodoItemPageCS(true);
			todoPage.BindingContext = todoItem;
			await Navigation.PushAsync(todoPage);
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var todoItem = e.SelectedItem as TodoItem;
			var todoPage = new TodoItemPageCS
			{
				BindingContext = todoItem
			};
			await Navigation.PushAsync(todoPage);
		}
	}
}
