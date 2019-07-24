using System.Collections.Generic;

namespace CollectionViewDemos.Models
{
    public class Animal : List<AnimalDetails>
    {
        public string Category { get; private set; }

        public Animal(string category, List<AnimalDetails> details) : base(details)
        {
            Category = category;
        }

        public override string ToString()
        {
            return Category;
        }
    }

    public class AnimalDetails
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
