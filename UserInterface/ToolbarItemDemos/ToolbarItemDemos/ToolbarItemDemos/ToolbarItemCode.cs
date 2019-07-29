using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ToolbarItemDemos
{
    public class ToolbarItemCode : ContentPage
    {
        Label messageLabel;

        public ToolbarItemCode()
        {
            Padding = 10;
            Title = "Code ToolbarItem Demo";

            ToolbarItem item1 = new ToolbarItem
            {
                Text = "Icon Item",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                IconImageSource = ImageSource.FromFile("icon.png")
            };

            ToolbarItem item2 = new ToolbarItem
            {
                Text = "Text Item",
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            ToolbarItem item3 = new ToolbarItem
            {
                Text = "Secondary Item",
                Order = ToolbarItemOrder.Secondary,
                Priority = 2,
                IconImageSource = ImageSource.FromFile("icon.png")
            };

            messageLabel = new Label
            {
                Text = "Click a toolbar item.",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout
            {
                Children = {
                    messageLabel
                }
            };

            ToolbarItems.Add(item1);
            ToolbarItems.Add(item2);
            ToolbarItems.Add(item3);

            item1.Clicked += OnItemClicked;
            item2.Clicked += OnItemClicked;
        }

        void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;
            messageLabel.Text = $"You clicked the \"{item.Text}\" toolbar item.";
        }
    }
}