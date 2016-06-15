using System.Collections.Generic;
using Xamarin.Forms;

namespace DataTemplates
{
	public class WithDataTemplatePageCS : ContentPage
	{
		public WithDataTemplatePageCS ()
		{
			Title = "With a Data Template";
			Icon = "csharp.png";

			var people = new List<Person> {
				new Person ("Steve", 21, "USA"),
				new Person ("John", 37, "USA"),
				new Person ("Tom", 42, "UK"),
				new Person ("Lucas", 29, "Germany"),
				new Person ("Tariq", 39, "UK"),
				new Person ("Jane", 30, "USA")
			};

			var personDataTemplate = new DataTemplate (() => {
				var grid = new Grid ();
				grid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (0.5, GridUnitType.Star) });
				grid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (0.2, GridUnitType.Star) });
				grid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (0.3, GridUnitType.Star) });

				var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
				var ageLabel = new Label ();
				var locationLabel = new Label { HorizontalTextAlignment = TextAlignment.End };

				nameLabel.SetBinding (Label.TextProperty, "Name");
				ageLabel.SetBinding (Label.TextProperty, "Age");
				locationLabel.SetBinding (Label.TextProperty, "Location");

				grid.Children.Add (nameLabel);
				grid.Children.Add (ageLabel, 1, 0);
				grid.Children.Add (locationLabel, 2, 0);

				return new ViewCell {
					View = grid
				};
			});

			var listView = new ListView { ItemsSource = people, ItemTemplate = personDataTemplate };

			Content = new StackLayout { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "ListView with a Data Template",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					listView
				}
			};
		}
	}
}
