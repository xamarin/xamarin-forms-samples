using System;
using Xamarin.QuickUI;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;


namespace Meetum.Views
{

    public class MapOptionsPage : ContentPage
    {
        static readonly List<OptionItem> OptionItems = new List<OptionItem> {
            new OptionItem { Title = "Dashboard", Subtitle = "" },
            new OptionItem { Title = "Favorites", Subtitle = "" },
            new OptionItem { Title = "Accounts", Subtitle = "3" },
            new OptionItem { Title = "Opportunities", Subtitle = "103" },
            new OptionItem { Title = "Leads", Subtitle = "203" },
            new OptionItem { Title = "Contacts", Subtitle = "392" },
            new OptionItem { Title = "Reminders", Subtitle = "9" },
            new OptionItem { Title = "Recents", Subtitle = "" },
        };

        public ListView Menu { get; set; }

        public MapOptionsPage ()
        {
            BackgroundColor = Color.FromHex("333333");

            var layout = new StackLayout { Spacing = 0 };

            var label = new ContentView {
                Padding = new Thickness(10, 36, 0, 5),
                BackgroundColor = Color.Transparent,
                Content = new Label {
                    Text = "Menu".ToUpper(), 
                    TextColor = Color.FromHex("AAAAAA")
                }
            };

            Device.OnPlatform (
                iOS: () => ((Label)label.Content).Font = Font.SystemFontOfSize (NamedSize.Micro),
                Android: () => ((Label)label.Content).Font = Font.SystemFontOfSize (NamedSize.Medium)
            );

            layout.Children.Add(label);

            Menu = new ListView {
                ItemSource = OptionItems,
                VerticalOptions = LayoutOptions.StartAndExpand,
                BackgroundColor = Color.Transparent
            };

            var cell = new DataTemplate(typeof(DarkTextCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(TextCell.DetailProperty, "Subtitle");

            Menu.ItemTemplate = cell;
            Menu.ItemTemplate.SetValue(VisualElement.BackgroundColorProperty, Color.Transparent);
            Menu.ItemTemplate.SetBinding(VisualElement.BackgroundColorProperty, "BackgroundColor");

            layout.Children.Add(Menu);

            Content = layout;
        }
    }

}

