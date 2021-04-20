using Xamarin.Forms;

namespace FlyoutPageNavigation
{
	public class TodoListPageCS : ContentPage
	{
		public TodoListPageCS ()
		{
			Title = "TodoList Page";
			Content = new StackLayout { 
				Children = {
					new Label {
						Text = "Todo list data goes here",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}
