using System;

namespace Selector
{
	public class Person
	{
		public string Name { get; private set; }

		public DateTime DateOfBirth { get; private set; }

		public string Location { get; private set; }

		public Person (string name, DateTime dob, string location)
		{
			Name = name;
			DateOfBirth = dob;
			Location = location;
		}
	}
}

