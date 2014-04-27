using System;
using Xamarin.QuickUI;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Meetum.Views
{

    public class CustomerMapOptionsView : ContentPage
    {
        static readonly List<OptionItem> OptionItems = new List<OptionItem> {
            new OptionItem { Title = "Zipcode", Subtitle = "94133" },
            new OptionItem { Title = "Region", Subtitle = "Jackson Heights" },
            new OptionItem { Title = "Zone", Subtitle = "5A" },
            new OptionItem { Title = "Distance", Subtitle = "3 miles" },
        };

        public CustomerMapOptionsView ()
        {
            BackgroundColor = Color.FromHex("333333");

            var layout = new StackLayout() { Spacing = 0 };

            var label = new ContentView {
                Padding = new Thickness(10, 36, 0, 5),
                BackgroundColor = Color.Transparent,
                Content = new Label {
                    Text = "Filter By".ToUpper(), 
                    Font = Font.SystemFontOfSize(NamedSize.Micro),
                    TextColor = Color.FromHex("AAAAAA")
                }
            };

            layout.Children.Add(label);

            var listView = new ListView {
                ItemSource = OptionItems,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Transparent
            };

            var cell = new DataTemplate(typeof(DarkTextCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(TextCell.DetailProperty, "Subtitle");

            listView.ItemTemplate = cell;
            listView.ItemTemplate.SetValue(VisualElement.BackgroundColorProperty, Color.Transparent);

            layout.Children.Add(listView);

            Content = layout;
        }
    }

}

