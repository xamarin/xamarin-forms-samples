using System.Collections.Generic;
using Xamarin.Forms;

namespace DataTemplates
{
    public class WithDataTemplatePageFromTypeCS : ContentPage
    {
        public WithDataTemplatePageFromTypeCS()
        {
            Title = "With a Data Template (Type)";
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

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label {
                        Text = "ListView with a Data Template (Type)",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new ListView { ItemsSource = people, ItemTemplate = new DataTemplate(typeof(PersonCellCS)), Margin = new Thickness(0, 20, 0, 0) }
                }
            };
        }
    }
}
