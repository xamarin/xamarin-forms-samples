using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Todo
{
	public class TodoListPageCS : ContentPage
	{
		ListView listView;

		public TodoListPageCS()
		{
			Title = "Todo";

			var toolbarItem = new ToolbarItem
			{
				Text = "+",
				Icon = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
			};
			toolbarItem.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new TodoItemPageCS
				{
					BindingContext = new TodoItem()
				});
			};
			ToolbarItems.Add(toolbarItem);

			listView = new ListView
			{
				Margin = new Thickness(20),
				ItemTemplate = new DataTemplate(() =>
				{
					var label = new Label
					{
						VerticalTextAlignment = TextAlignment.Center,
						HorizontalOptions = LayoutOptions.StartAndExpand
					};
					label.SetBinding(Label.TextProperty, "Name");

					var tick = new Image
					{
						Source = ImageSource.FromFile("check.png"),
						HorizontalOptions = LayoutOptions.End
					};
					tick.SetBinding(VisualElement.IsVisibleProperty, "Done");

					var stackLayout = new StackLayout
					{
						Margin = new Thickness(20, 0, 0, 0),
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = { label, tick }
					};

					return new ViewCell { View = stackLayout };
				})
			};
			listView.ItemSelected += async (sender, e) =>
			{
                //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
                //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);

                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new TodoItemPageCS
                    {
                        BindingContext = e.SelectedItem as TodoItem
                    });
                }
			};

			Content = listView;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtTodoId = -1;
			listView.ItemsSource = await App.Database.GetItemsAsync();
		}
	}
}
