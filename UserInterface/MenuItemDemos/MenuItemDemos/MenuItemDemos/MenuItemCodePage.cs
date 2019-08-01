using MenuItemDemos.Services;
using System;

using Xamarin.Forms;

namespace MenuItemDemos
{
    public class MenuItemCodePage : ContentPage
    {
        Label messageLabel;

        public MenuItemCodePage()
        {
            Padding = 10;
            Title = "MenuItem Code Demo";

            messageLabel = new Label
            {
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            var dataTemplate = new DataTemplate(() =>
            {
                var label = new Label();
                label.SetBinding(Label.TextProperty, ".");
                var viewCell = new ViewCell
                {
                    View = label
                };

                var menuItem1 = new MenuItem
                {
                    Text = "Edit",
                    IconImageSource = ImageSource.FromFile("icon.png")
                };
                menuItem1.Clicked += EditClicked;

                var menuItem2 = new MenuItem
                {
                    Text = "Delete"
                };
                menuItem2.Clicked += DeleteClicked;

                viewCell.ContextActions.Add(menuItem1);
                viewCell.ContextActions.Add(menuItem2);

                return viewCell;
            });

            var listView = new ListView
            {
                ItemsSource = DataService.GetListItems(),
                ItemTemplate = dataTemplate
            };

            Content = new StackLayout
            {
                Children = {
                    messageLabel,
                    listView
                }
            };
        }

        void DeleteClicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            messageLabel.Text = $"Delete handler was called on {item.BindingContext}";
        }

        void EditClicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            messageLabel.Text = $"Edit handler was called on {item.BindingContext}";
        }
    }
}