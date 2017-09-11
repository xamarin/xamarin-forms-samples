using System.Collections.Generic;
using Xamarin.Forms;

namespace DataTemplates
{
    public class WithDataTemplatePageCS : ContentPage
    {
        public WithDataTemplatePageCS()
        {
            Title = "With a Data Template";
            Icon = "csharp.png";

            var people = new List<Person>
            {
                new Person { Name = "Steve", Age = 21, Location = "USA" },
                new Person { Name = "John", Age = 37, Location = "USA" },
                new Person { Name = "Tom", Age = 42, Location = "UK" },
                new Person { Name = "Lucas", Age = 29, Location = "Germany" },
                new Person { Name = "Tariq", Age = 39, Location = "UK" },
                new Person { Name = "Jane", Age = 30, Location = "USA" }
            };

            var personDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                var ageLabel = new Label();
                var locationLabel = new Label { HorizontalTextAlignment = TextAlignment.End };

                nameLabel.SetBinding(Label.TextProperty, "Name");
                ageLabel.SetBinding(Label.TextProperty, "Age");
                locationLabel.SetBinding(Label.TextProperty, "Location");

                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel, 1, 0);
                grid.Children.Add(locationLabel, 2, 0);

                return new ViewCell
                {
                    View = grid
                };
            });

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label {
                        Text = "ListView with a Data Template",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new ListView { ItemsSource = people, ItemTemplate = personDataTemplate, Margin = new Thickness(0, 20, 0, 0) }
                }
            };
        }
    }
}
