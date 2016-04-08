using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Selector
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

			var people = new List<Person> {
				new Person ("Kath", new DateTime (1985, 11, 20), "France"),
				new Person ("Steve", new DateTime (1975, 1, 15), "USA"),
				new Person ("Lucas", new DateTime (1988, 2, 5), "Germany"),
				new Person ("John", new DateTime (1976, 2, 20), "USA"),
				new Person ("Tariq", new DateTime (1987, 1, 10), "UK"),
				new Person ("Jane", new DateTime (1982, 8, 30), "USA"),
				new Person ("Tom", new DateTime (1977, 3, 10), "UK")
			};

			listView.ItemsSource = people;
		}
	}
}
