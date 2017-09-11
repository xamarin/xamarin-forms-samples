using System.Collections.Generic;
using Xamarin.Forms;

namespace DataTemplates
{
    public class WithoutDataTemplatePageCS : ContentPage
    {
        public WithoutDataTemplatePageCS()
        {
            Title = "Without a Data Template";
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
                        Text = "ListView without a Data Template",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new ListView { ItemsSource = people, Margin = new Thickness(0, 20, 0, 0) }
                }
            };
        }
    };
}
