using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BindingContextChanged
{
	public partial class ListPage : ContentPage
	{
		public ListPage ()
		{
			InitializeComponent ();
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			var people = new List<Person> {
				new Person ("Steve", 21, "USA"),
				new Person ("John", 37, "USA"),
				new Person ("Tom", 42, "UK"),
				new Person ("Lucas", 29, "Germany"),
				new Person ("Tariq", 39, "UK"),
				new Person ("Jane", 30, "USA")
			};

			listView.ItemsSource = people;
		}
	}
}

