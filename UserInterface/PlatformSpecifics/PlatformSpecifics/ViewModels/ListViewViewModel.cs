using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PlatformSpecifics
{
    public class ListViewViewModel
    {
        public ObservableCollection<Grouping<char, Person>> GroupedEmployees { get; private set; }

        public ListViewViewModel()
        {
			var rnd = new Random();
			var employees = new List<Person>();
			Enumerable.Range(0, 1000)
					  .Select(p => new Person(string.Format("{0}, {1}", Faker.Name.Last(), Faker.Name.First()), rnd.Next(18, 65)))
					  .ForEach(p => employees.Add(p));
			GroupedEmployees = new ObservableCollection<Grouping<char, Person>>(employees.OrderBy(e => e.Name[0]).GroupBy(e => e.Name[0]).Select(e => new Grouping<char, Person>(e.Key, e)));
        }
    }
}
