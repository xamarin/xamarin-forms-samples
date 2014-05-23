using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;
using MobileCRM.Shared.Models;
using MobileCRM.Shared.CustomViews;


namespace MobileCRM.Shared.Pages
{

    public class MenuPage : ContentPage
    {
        static readonly List<OptionItem> OptionItems = new List<OptionItem> {
            new OptionItem { Title = "Favorites", Subtitle = "" },
            new OptionItem { Title = "Accounts", Subtitle = "3" },
            new OptionItem { Title = "Opportunities", Subtitle = "103" },
            new OptionItem { Title = "Leads", Subtitle = "203" },
            new OptionItem { Title = "Contacts", Subtitle = "392" },
            new OptionItem { Title = "Reminders", Subtitle = "9" },
            new OptionItem { Title = "Recents", Subtitle = "" },
        };

        public ListView Menu { get; set; }

        public MenuPage ()
        {
            var layout = new StackLayout { Spacing = 0, VerticalOptions = LayoutOptions.FillAndExpand };

            var label = new ContentView {
                Padding = new Thickness(10, 36, 0, 5),
                Content = new Xamarin.Forms.Label {
                    Text = "MENU", 
                }
            };

            Device.OnPlatform (
                iOS: () => ((Xamarin.Forms.Label)label.Content).Font = Font.SystemFontOfSize (NamedSize.Micro),
                Android: () => ((Xamarin.Forms.Label)label.Content).Font = Font.SystemFontOfSize (NamedSize.Medium)
            );

            layout.Children.Add(label);

            Menu = new ListView {
                ItemSource = OptionItems,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var cell = new DataTemplate(typeof(DarkTextCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(TextCell.DetailProperty, "Subtitle");

            Menu.ItemTemplate = cell;

            layout.Children.Add(Menu);

            Content = layout;
        }
    }

}

