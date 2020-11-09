namespace ResourceDictionaryDemo
{
	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Location { get; set; }

        public Person()
        {
        }

		public Person (string name, int age, string location)
		{
			Name = name;
			Age = age;
			Location = location;
		}

		public override string ToString ()
		{
			return Name;
		}
	}
}

