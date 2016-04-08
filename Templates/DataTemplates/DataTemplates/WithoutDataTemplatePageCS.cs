using System.Collections.Generic;
using Xamarin.Forms;

namespace DataTemplates
{
	public class WithoutDataTemplatePageCS : ContentPage
	{
		public WithoutDataTemplatePageCS ()
		{
			Title = "Without a Data Template";
			Icon = "csharp.png";

			var people = new List<Person> {
				new Person ("Steve", 21, "USA"),
				new Person ("John", 37, "USA"),
				new Person ("Tom", 42, "UK"),
				new Person ("Lucas", 29, "Germany"),
				new Person ("Tariq", 39, "UK"),
				new Person ("Jane", 30, "USA")
			};

			var listView = new ListView { ItemsSource = people };

			Content = new StackLayout { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "ListView without a Data Template",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					listView
				}
			};
		}
	}
}
