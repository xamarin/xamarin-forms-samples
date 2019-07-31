using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MenuItemDemos
{
    public class MenuItemCodePage : ContentPage
    {
        public MenuItemCodePage()
        {
            Padding = 10;
            Title = "MenuItem Code Demo";


            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}