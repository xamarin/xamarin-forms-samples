using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Selector
{
    public class HomePageCS : ContentPage
    {
        DataTemplate validTemplate;
        DataTemplate invalidTemplate;

        public HomePageCS()
        {
            var people = new List<Person>
            {
                new Person { Name = "Kath", DateOfBirth = new DateTime(1985, 11, 20), Location = "France" },
                new Person { Name = "Steve", DateOfBirth = new DateTime(1975, 1, 15), Location = "USA" },
                new Person { Name = "Lucas", DateOfBirth = new DateTime(1988, 2, 5), Location = "Germany" },
                new Person { Name = "John", DateOfBirth = new DateTime(1976, 2, 20), Location = "USA" },
                new Person { Name = "Tariq", DateOfBirth = new DateTime(1987, 1, 10), Location = "UK" },
                new Person { Name = "Jane", DateOfBirth = new DateTime(1982, 8, 30), Location = "USA" },
                new Person { Name = "Tom", DateOfBirth = new DateTime(1977, 3, 10), Location = "UK" }
            };

            SetupDataTemplates();

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label {
                        Text = "ListView with a DataTemplateSelector",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new ListView {
                        Margin = new Thickness(0,20,0,0),
                        ItemsSource = people,
                        ItemTemplate = new PersonDataTemplateSelector {
                            ValidTemplate = validTemplate,
                            InvalidTemplate = invalidTemplate
                        }
                    }
                }
            };
        }

        void SetupDataTemplates()
        {
            validTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.4, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                var dobLabel = new Label();
                var locationLabel = new Label { HorizontalTextAlignment = TextAlignment.End };

                nameLabel.SetBinding(Label.TextProperty, "Name");
                dobLabel.SetBinding(Label.TextProperty, "DateOfBirth", stringFormat: "{0:d}");
                locationLabel.SetBinding(Label.TextProperty, "Location");
                nameLabel.TextColor = Color.Green;
                dobLabel.TextColor = Color.Green;
                locationLabel.TextColor = Color.Green;

                grid.Children.Add(nameLabel);
                grid.Children.Add(dobLabel, 1, 0);
                grid.Children.Add(locationLabel, 2, 0);

                return new ViewCell
                {
                    View = grid
                };
            });

            invalidTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.4, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                var dobLabel = new Label();
                var locationLabel = new Label { HorizontalTextAlignment = TextAlignment.End };

                nameLabel.SetBinding(Label.TextProperty, "Name");
                dobLabel.SetBinding(Label.TextProperty, "DateOfBirth", stringFormat: "{0:d}");
                locationLabel.SetBinding(Label.TextProperty, "Location");
                nameLabel.TextColor = Color.Red;
                dobLabel.TextColor = Color.Red;
                locationLabel.TextColor = Color.Red;

                grid.Children.Add(nameLabel);
                grid.Children.Add(dobLabel, 1, 0);
                grid.Children.Add(locationLabel, 2, 0);

                return new ViewCell
                {
                    View = grid
                };
            });
        }
    }
}
