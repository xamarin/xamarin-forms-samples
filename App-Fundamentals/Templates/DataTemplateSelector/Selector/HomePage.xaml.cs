using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Selector
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

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

            listView.ItemsSource = people;
        }
    }
}
