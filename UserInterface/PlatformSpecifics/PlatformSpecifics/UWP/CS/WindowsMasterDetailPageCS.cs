using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public partial class WindowsMasterDetailPageCS : Xamarin.Forms.MasterDetailPage
    {
        Xamarin.Forms.Page detailPage;
        ICommand _returnToPlatformSpecificsPage;

        public WindowsMasterDetailPageCS(ICommand restore)
        {
            _returnToPlatformSpecificsPage = restore;

            On<Windows>().SetCollapseStyle(CollapseStyle.Partial);
            MasterBehavior = MasterBehavior.Popover;

            Master = CreateMasterPage();
            Detail = detailPage = CreateDetailPage();
            WindowsPlatformSpecificsHelpers.AddToolBarItems(this);
        }

        ContentPage CreateMasterPage()
        {
            var items = new List<NavigationItem>
            {
                new NavigationItem("Save", "\uE105", new Command(async () => await DisplayAlert("Save", "Fake save dialog", "OK"))),
                new NavigationItem("Delete", "\uE107", new Command(async () => await DisplayAlert("Delete", "Fake delete dialog", "OK"))),
                new NavigationItem("Set Detail to Navigation Page", "\uE16F", new Command(() => Detail = new NavigationPage(CreateContentPageTwo()))),
                new NavigationItem("Set Detail to Content Page", "\uE160", new Command(() => Detail = detailPage)),
                new NavigationItem("Back", "\uE106", _returnToPlatformSpecificsPage)
            };

            var listView = new Xamarin.Forms.ListView
            {
                ItemsSource = items,
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid { Margin = new Thickness(0, 10, 0, 10), WidthRequest = 40 };
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 48 });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 200 });

                    var iconLabel = new Label
                    {
                        FontFamily = "Segoe MDL2 Assets",
                        FontSize = 24,
                        HorizontalTextAlignment = TextAlignment.Center
                    };
                    iconLabel.SetBinding(Label.TextProperty, "Icon");

                    var textLabel = new Label();
                    textLabel.SetBinding(Label.TextProperty, "Text");

                    grid.Children.Add(iconLabel);
                    grid.Children.Add(textLabel);
                    Grid.SetColumn(iconLabel, 0);
                    Grid.SetColumn(textLabel, 1);

                    var cell = new ViewCell { View = grid };
                    return cell;
                })
            };
            listView.ItemTapped += (sender, e) => (e.Item as NavigationItem).Command.Execute(null);

            return new ContentPage
            {
                Title = "Master Page",
                Content = new StackLayout
                {
                    Margin = new Thickness(0, 10, 5, 0),
                    Spacing = 10,
                    Children = { listView }
                }
            };
        }

        ContentPage CreateDetailPage()
        {
            var returnButton = new Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => _returnToPlatformSpecificsPage.Execute(null);

            return new ContentPage
            {
                Title = "Detail Page",
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new Label { Text = "Toolbar Items", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                        WindowsPlatformSpecificsHelpers.CreateAddRemoveToolbarItemButtons(this),
                        WindowsPlatformSpecificsHelpers.CreateToolbarPlacementChanger(this),
                        CreateCollapseWidthAdjuster(this),
                        CreateCollapseStyleChanger(this),
                        returnButton
                    }
                }
            };
        }

        ContentPage CreateContentPageTwo()
        {
            var returnButton = new Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => _returnToPlatformSpecificsPage.Execute(null);

            return new ContentPage
            {
                Title = "ContentPage Two",
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new Label { Text = "Toolbar placement and number of items doesn't change", HorizontalOptions = LayoutOptions.Center },
                        returnButton
                    }
                }
            };
        }

        static Layout CreateCollapseStyleChanger(Xamarin.Forms.MasterDetailPage page)
        {
            var enumType = typeof(CollapseStyle);

            return WindowsPlatformSpecificsHelpers.CreateChanger(enumType, Enum.GetName(enumType, page.On<Windows>().GetCollapseStyle()), picker =>
            {
                page.On<Windows>().SetCollapseStyle((CollapseStyle)Enum.Parse(enumType, picker.Items[picker.SelectedIndex]));
            }, "Select Collapse Style");
        }

        static Layout CreateCollapseWidthAdjuster(Xamarin.Forms.MasterDetailPage page)
        {
            var label = new Label
            {
                Text = "Adjust Collapsed Width",
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var entry = new Entry { Text = page.On<Windows>().CollapsedPaneWidth().ToString() };
            var button = new Button { Text = "Change", BackgroundColor = Color.Gray };
            button.Clicked += (sender, e) =>
            {
                double width;
                if (double.TryParse(entry.Text, out width))
                {
                    page.On<Windows>().CollapsedPaneWidth(width);
                }
            };

            return new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { label, entry, button }
            };
        }
    }
}
