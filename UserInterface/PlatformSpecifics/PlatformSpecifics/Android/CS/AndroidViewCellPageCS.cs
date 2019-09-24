using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Button = Xamarin.Forms.Button;
using ListView = Xamarin.Forms.ListView;
using ViewCell = Xamarin.Forms.ViewCell;

namespace PlatformSpecifics
{
    public class AndroidViewCellPageCS : ContentPage
    {
        public AndroidViewCellPageCS()
        {
            Button button = new Button
            {
                Text = "Toggle Legacy Mode"
            };
            button.SetBinding(Button.CommandProperty, "ToggleLegacyMode");

            DataTemplate oneItemTemplate = new DataTemplate(() =>
            {
                Label label = new Label();
                label.SetBinding(Label.TextProperty, "Text");

                ViewCell viewCell = new ViewCell
                {
                    View = label
                };
                button.Clicked += (s, e) =>
                {
                    viewCell.On<Android>().SetIsContextActionsLegacyModeEnabled(!viewCell.On<Android>().GetIsContextActionsLegacyModeEnabled());
                };

                MenuItem menuItem = new MenuItem();
                menuItem.SetBinding(MenuItem.TextProperty, "Item1Text");
                
                viewCell.ContextActions.Add(menuItem);
                return viewCell;
            });

            DataTemplate twoItemsTemplate = new DataTemplate(() =>
            {
                Label label = new Label();
                label.SetBinding(Label.TextProperty, "Text");

                ViewCell viewCell = new ViewCell
                {
                    View = label
                };

                button.Clicked += (s, e) =>
                {
                    viewCell.On<Android>().SetIsContextActionsLegacyModeEnabled(!viewCell.On<Android>().GetIsContextActionsLegacyModeEnabled());
                };

                MenuItem menuItem1 = new MenuItem();
                menuItem1.SetBinding(MenuItem.TextProperty, "Item1Text");
                MenuItem menuItem2 = new MenuItem();
                menuItem2.SetBinding(MenuItem.TextProperty, "Item2Text");
                
                viewCell.ContextActions.Add(menuItem1);
                viewCell.ContextActions.Add(menuItem2);
                return viewCell;
            });

            ItemDataTemplateSelector itemDataTemplateSelector = new ItemDataTemplateSelector
            {
                OneItemTemplate = oneItemTemplate,
                TwoItemsTemplate = twoItemsTemplate
            };

            ListView listView = new ListView
            {
                ItemTemplate = itemDataTemplateSelector
            };
            listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "Items");

            BindingContext = new AndroidViewCellPageViewModel();
            Title = "ViewCell Context Actions";
            Content = new StackLayout
            {
                Children =
                {
                    new StackLayout
                    {
                        Margin = new Thickness(20),
                        Children =
                        {
                            button,
                            listView
                        }
                    }
                }
            };
        }
    }
}
