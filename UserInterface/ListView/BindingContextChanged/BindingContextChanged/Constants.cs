using BindingContextChanged.ViewModels;
using System.Collections.Generic;

namespace BindingContextChanged
{
    public static class Constants
    {
        public static List<Person> People = new List<Person>
        {
            new Person("Steve", 21, "USA"),
            new Person("John", 37, "USA"),
            new Person("Tom", 42, "UK"),
            new Person("Lucas", 29, "Germany"),
            new Person("Tariq", 39, "UK"),
            new Person("Jane", 30, "USA")
        };
    }
}
